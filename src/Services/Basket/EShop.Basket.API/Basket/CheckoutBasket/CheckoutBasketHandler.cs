namespace EShop.Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketHandler(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        //DONE get the basket
        //DONE set total price on the basket event message
        //DONE send the basket event message to the bus
        //DONE delete the basket

        //UNIT-TEST: BasketCheckoutHandlerTests
        var basket = await basketRepository.GetBasketAsync(command.BasketCheckoutDto.UserName, cancellationToken);

        if (!basket.Items.Any()) return new CheckoutBasketResult(false);

        //TODO Validate the basket items and total price
        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await basketRepository.DeleteBasketAsync(command.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutBasketResult(true);
    }
}
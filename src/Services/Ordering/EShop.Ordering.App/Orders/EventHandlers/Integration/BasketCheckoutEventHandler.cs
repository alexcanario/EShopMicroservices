namespace EShop.Ordering.App.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger)
	: IConsumer<BasketCheckoutEvent>
{
	public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
	{
		//TODO Create an order based on the basket checkout event
		logger.LogInformation("Integration Event Handler: {IntegrationEvent}", context.Message.GetType().Name);

		//TODO Validate ToCreateOrderCommand
		var command = context.Message.ToCreateOrderCommand();

		await sender.Send(command);
	}
}
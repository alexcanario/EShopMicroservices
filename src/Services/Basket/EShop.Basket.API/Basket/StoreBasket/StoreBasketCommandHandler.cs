namespace EShop.Basket.API.Basket.StoreBasket;

public sealed record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public sealed record StoreBasketResult(bool IsSucess, string Username);

public class StoreBasketValidation: AbstractValidator<StoreBasketCommand>
{
	public StoreBasketValidation()
	{
		RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null!");
		RuleFor(x => x.Cart.Username).NotEmpty().WithMessage("Username is required");
		RuleFor(x => x.Cart.Items).Must(x => x.Count > 0).WithMessage("Cart should have at least one item");
	}
}
public class StoreBasketCommandHandler(IBasketRepository BasketRepository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
	public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
	{
		//TODO: Store the cart in the database (using marten upsert support)
		var storedCart = await BasketRepository.StoreBasketAsync(command.Cart, cancellationToken);

		//TODO: Update cache with the cart


		return storedCart is null 
			? new StoreBasketResult(false, "Store Basket Error")
			: new StoreBasketResult(true, storedCart.Username);
	}
}
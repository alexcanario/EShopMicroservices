using EShop.Discount.Grpc;

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
public class StoreBasketCommandHandler(IBasketRepository BasketRepository, DiscountProtoService.DiscountProtoServiceClient discountProto) 
	: ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
	public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
	{
		//DONE: Store the cart in the database (using marten upsert support)
		//DONE: Update cache with the cart
		await DeductDiscount(command.Cart, cancellationToken).ConfigureAwait(false);
		var storedCart = await BasketRepository.StoreBasketAsync(command.Cart, cancellationToken);

		return storedCart is null 
			? new StoreBasketResult(false, "Store Basket Error")
			: new StoreBasketResult(true, storedCart.Username);
	}

	private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellation)
	{
		foreach (var item in cart.Items)
		{
			if(item is null) continue;

			var coupoun = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
			item.Price -= coupoun.Amount;
		}
	}
}
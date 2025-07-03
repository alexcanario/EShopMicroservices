namespace EShop.Basket.API.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProtoService) 
	: ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
	public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
	{
		//DONE Store the cart in the database (using marten upsert support)
		//DONE Update cache with the cart
		await DeductDiscount(command.Cart, cancellationToken).ConfigureAwait(false);
		var storedCart = await basketRepository.StoreBasketAsync(command.Cart, cancellationToken);

		return new StoreBasketResult(true, storedCart.Username);
	}

	private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellation)
	{
		foreach (var item in cart.Items)
		{
			if(string.IsNullOrEmpty(item.ProductName) || item.Price <= 0) continue;

			var coupon = await discountProtoService.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
			item.Price -= coupon.Amount;
		}
	}
}
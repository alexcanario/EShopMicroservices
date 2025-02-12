namespace EShop.Basket.API.Data;

public class BasketRepository(IDocumentSession Session) : IBasketRepository
{
	public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
	{
		Session.Delete<ShoppingCart>(userName);
		await Session.SaveChangesAsync(cancellationToken);
		return true;
	}

	public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
	{
		var basket = await Session.LoadAsync<ShoppingCart>(userName, cancellationToken);
		return basket is null ? throw new BasketNotFoundException(userName) : basket;
	}

	public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
	{
		Session.Store(basket);
		await Session.SaveChangesAsync(cancellationToken);
		return basket;
	}
}
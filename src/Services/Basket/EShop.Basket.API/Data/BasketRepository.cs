namespace EShop.Basket.API.Data;

public class BasketRepository(IDocumentSession Session) : IBasketRepository
{
	public async Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken)
	{
		Session.Delete<ShoppingCart>(userName);
		await Session.SaveChangesAsync(cancellationToken);
		return true;
	}

	public async ValueTask<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken)
	{
		var basket = await Session.LoadAsync<ShoppingCart>(userName, cancellationToken);
		return basket ?? throw new BasketNotFoundException(userName);
	}

	public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken)
	{
		Session.Store(basket);
		await Session.SaveChangesAsync(cancellationToken);
		return basket;
	}
}
namespace EShop.Basket.API.Data;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    public async Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken)
	{
        session.Delete<ShoppingCart>(userName);
		await session.SaveChangesAsync(cancellationToken);
		return true;
	}

	public async ValueTask<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken)
	{
		var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);

        //todo: logar if basket is null
        //Implementar result pattern to return null 
        return basket ?? throw new BasketNotFoundException(userName);
	}

	public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken)
	{
		session.Store(basket);
		await session.SaveChangesAsync(cancellationToken);
		return basket;
	}
}
namespace EShop.Basket.API.Data;

public interface IBasketRepository
{
	ValueTask<ShoppingCart> GetBasketAsync(string userName, CancellationToken	cancellationToken);
	Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken);
	Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken);
}
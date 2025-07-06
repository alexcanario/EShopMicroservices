namespace EShop.Basket.API.Data;

public sealed class CachedBasketRepository(IBasketRepository basketRepository, IDistributedCache cache) : IBasketRepository
{
	public async Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken)
	{
		await basketRepository.DeleteBasketAsync(userName, cancellationToken);
		await cache.RemoveAsync(userName, cancellationToken);

		return true;
	}

	public async ValueTask<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken)
	{
		var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);

		if(!string.IsNullOrEmpty(cachedBasket))
			return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

		var basket = await basketRepository.GetBasketAsync(userName, cancellationToken);
		await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);

		return basket;
	}

	public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken)
	{
		await basketRepository.StoreBasketAsync(basket, cancellationToken);
		await cache.SetStringAsync(basket.Username, JsonSerializer.Serialize(basket), cancellationToken);

		return basket;
	}
}
using EShop.Basket.API.Data;

namespace EShop.Basket.API.Basket.GetBasket;

public sealed record GetBasketQuery(string Username) : IQuery<GetBasketResult>;
public sealed record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler(IBasketRepository BasketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
	public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
	{
		//TODO: get basket from repository
		var basket = await BasketRepository.GetBasketAsync(query.Username, cancellationToken);

		return basket is null 
			? new GetBasketResult(new ShoppingCart(query.Username))
			: new GetBasketResult(basket);
	}
}
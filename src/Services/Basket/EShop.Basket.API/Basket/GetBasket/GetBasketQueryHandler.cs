namespace EShop.Basket.API.Basket.GetBasket;

public sealed record GetBasketQuery(string Username) : IQuery<GetBasketResult>;
public sealed record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
	public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
	{
		//TODO: get basket from repository
		//var basket = await _repository.GetBasketAsync(request.Username);

		return new GetBasketResult(new ShoppingCart(query.Username));
	}
}
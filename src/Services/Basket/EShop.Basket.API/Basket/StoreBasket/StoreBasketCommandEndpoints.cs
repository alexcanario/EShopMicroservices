namespace EShop.Basket.API.Basket.StoreBasket;

public record StoreBasketResponse(bool IsSucess, string Username);
public record StoreBasketRequest(ShoppingCart Cart) : IRequest<StoreBasketResponse>;

public class StoreBasketCommandEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/basket", async (ShoppingCart cart, ISender sender) =>
		{
			var response = await sender.Send(new StoreBasketRequest(cart));

			return response.IsSucess
				? Results.Ok(response.Adapt<StoreBasketResponse>())
				: Results.BadRequest();
		})
			.WithName("GetBasket")
			.WithDescription("Get the basket for the user")
			.WithSummary("Get the basket for the user")
			.Produces<StoreBasketResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
using Mapster;

namespace EShop.Basket.API.Basket.GetBasket;

//public sealed record GetBasketRequest(string Username);
public sealed record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/basket/{username}", async (string username, ISender sender) => 
		{ 
			var result = await sender.Send(new GetBasketQuery(username));
			var response = result.Adapt<GetBasketResponse>();
			return Results.Ok(response);
		}).WithName("GetBasket")
			.WithDescription("Get basket by username")
			.WithSummary("Get basket by username")
			.Produces<GetBasketResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
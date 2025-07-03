namespace EShop.Basket.API.Basket.StoreBasket;

public class StoreBasketCommandEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
		{
			var command = request.Adapt<StoreBasketCommand>();
			
			var response = await sender.Send(command);

			return response.IsSuccess
				? Results.Created($"/basket/{response.Username}", response)
				: Results.BadRequest();
		})
			.WithName("StoreBasket")
			.WithDescription("Get the basket for the user")
			.WithSummary("Get the basket for the user")
			.Produces<StoreBasketResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
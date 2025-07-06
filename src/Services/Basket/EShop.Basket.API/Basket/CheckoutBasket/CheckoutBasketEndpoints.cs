namespace EShop.Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
		{
			var command = request.Adapt<CheckoutBasketCommand>();

			var result = await sender.Send(command);

			var response = result.Adapt<CheckoutBasketResponse>();

			return response.IsSuccess
				? Results.Ok(response)
				: Results.BadRequest(response);
		})
		.WithName("CheckoutBasket")
		.WithDescription("Checkout the basket for the user")
		.WithSummary("Checkout the basket for the user")
		.Produces<CheckoutBasketResponse>()
		.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
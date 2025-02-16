namespace EShop.Basket.API.Basket.DeleteBasket;

public record DeleteBasketResponse(bool IsDeleted);
public record DeleteBasketRequest(string Username);

public class DeleteBasketCommandEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapDelete("/basket/{username}", async (string username, ISender sender) => 
		{ 
			var response = await sender.Send(new DeleteBasketCommand(username));
			return response.IsDeleted 
			? Results.Ok(new DeleteBasketResponse(response.IsDeleted))
			: Results.BadRequest();
		})
			.WithName("DeleteBasket")
			.WithDescription("Delete a basket")
			.WithSummary("Delete a basket")
			.Produces<DeleteBasketResponse>()
			.ProducesProblem(StatusCodes.Status400BadRequest);

	}
}
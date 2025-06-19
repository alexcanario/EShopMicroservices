namespace EShop.Ordering.API.Endpoints;

public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderResponse(bool SuccessFully);

public class UpdateOrder : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
		{
			var command = request.Adapt<UpdateOrderCommand>();
			var result = await sender.Send(command);
			
			return Results.Ok(new UpdateOrderResponse(result.Successfully));
		})
			.WithName("UpdateOrder")
			.Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithSummary("UpdateOrder")
			.WithDescription("Updates an existing order. The order must have a valid ID, customer ID, and at least one item.");
	}
}
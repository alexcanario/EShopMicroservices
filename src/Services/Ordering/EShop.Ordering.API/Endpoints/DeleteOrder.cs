using EShop.Ordering.App.Orders.Commands.DeleteOrder;

namespace EShop.Ordering.API.Endpoints;

//public record DeleteOrderRequest(Guid Id);
public record DeleteOrderResponse(bool IsDeleted);

public class DeleteOrder : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapDelete("/Orders/{id:guid}", async (Guid id, ISender sender) =>
		{
			var result = await sender.Send(new DeleteOrderCommand(id));
			var response = result.Adapt<DeleteOrderResponse>();

			return response.IsDeleted
				? Results.Ok(response)
				: Results.NotFound(response);
		})
			.WithName("DeleteOrder")
			.Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.WithSummary("DeleteOrder")
			.WithDescription("Deletes an existing order by its ID. If the order is not found, it returns a 404 Not Found response.");

	}
}
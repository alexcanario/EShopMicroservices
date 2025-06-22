namespace EShop.Ordering.API.Endpoints;

public record GetOrderByNameRequest(string OrderName);

public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrderByName : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders/{orderName}", async ([AsParameters] GetOrderByNameRequest request, ISender sender) =>
		{
			var response = await sender.Send(new GetOrdersByNameQuery(request.OrderName));

			var result = response.Adapt<GetOrderByNameResponse>();

			return result.Orders.Any()
				? Results.Ok(result)
				: Results.NotFound();
		})
		.WithName("GetOrderByName")
		.Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status404NotFound)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("GetOrderByName")
		.WithDescription("Retrieves orders by their name. If no orders are found, it returns a 404 Not Found response.");
	}
}
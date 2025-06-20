namespace EShop.Ordering.API.Endpoints;

public class GetOrders : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
		{
			if(request.PageSize <= 0 || request.PageIndex < 0)
			{
				return Results.BadRequest("Invalid pagination parameters.");
			}
			
			var result = await sender.Send(new GetOrdersQuery(request));
			
			var response = result.Adapt<GetOrdersResult>();
			return response.Orders.Data.Any() 
				? Results.Ok(response)
				: Results.NoContent();
		})
			.WithName("GetOrders")
			.Produces<GetOrdersResult>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status204NoContent)
			.WithSummary("GetOrders")
			.WithDescription("Retrieves a paginated list of orders. If no orders are found, it returns a 404 Not Found response.");
	}
}
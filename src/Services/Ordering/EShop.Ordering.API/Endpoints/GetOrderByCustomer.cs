namespace EShop.Ordering.API.Endpoints;

//public record GetOrderByCustomerRequest(Guid CustomerId);
public record GetOrderByCustomerResponse(IEnumerable<OrderDto> Orders);

public class GetOrderByCustomer : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders/customer/{customerId:guid}", async (Guid customerId, ISender sender) =>
		{
			var response = await sender.Send(new GetOrdersByCustomerQuery(customerId));
			var result = response.Adapt<GetOrderByCustomerResponse>();
			return result.Orders.Any()
				? Results.Ok(result)
				: Results.NotFound();
		})
		.WithName("GetOrderByCustomer")
		.Produces<GetOrderByCustomerResponse>()
		.ProducesProblem(StatusCodes.Status404NotFound)
		.WithSummary("GetOrderByCustomer")
		.WithDescription("Retrieves all orders for a specific customer. The customer ID must be valid and the customer must have at least one order.");
	}
}
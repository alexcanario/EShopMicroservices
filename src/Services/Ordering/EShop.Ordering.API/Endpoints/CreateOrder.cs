namespace EShop.Ordering.API.Endpoints;

public record CreateOrderRequest(OrderDto Order);
public record CreateOrderResponse(Guid OrderId);

public class CreateOrder : ICarterModule
{
	//Accept POST requests to create a new order
	//Maps the request to a CreateOrderCommand
	//Uses MediatR to send the command
	//Returns a 201 Created response with the order ID in the Location header
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
		{
			var command = request.Adapt<CreateOrderCommand>();
			var result = await sender.Send(command);
			var response = result.Adapt<CreateOrderResponse>();

			return Results.Created($"/orders/{response.OrderId}", response);
		})
		.WithName("CreateOrder")
		.Produces<CreateOrderResponse>(StatusCodes.Status201Created)
		.ProducesProblem(StatusCodes.Status404NotFound)
		.WithSummary("CreateOrder")
		.WithDescription("Creates a new order for the customer. The order must have at least one item and a valid customer ID.");
	}
}
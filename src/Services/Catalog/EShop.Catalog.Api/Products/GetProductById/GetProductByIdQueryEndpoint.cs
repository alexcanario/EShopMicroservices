namespace EShop.Catalog.Api.Products.GetProductById;

internal sealed record GetProductByIdResponse(Product Product);
//internal sealed record GetProductByIdRequest(Guid Id);
public class GetProductByIdQueryEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
		{
			var result = await sender.Send(new GetProductByIdQuery(id));
			var response = result.Adapt<GetProductByIdResponse>();
			return Results.Ok(response);
		})
			.WithName("GetProductById")
			.WithDescription("Get product by id")
			.WithSummary("Get product by id")
			.Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
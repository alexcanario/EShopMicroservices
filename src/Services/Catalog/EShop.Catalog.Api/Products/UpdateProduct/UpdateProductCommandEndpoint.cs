namespace EShop.Catalog.Api.Products.UpdateProduct;

public sealed record UpdateProductRequest(Guid Id, string Name, string Description, decimal Price, string ImageFile, IList<string> Category);
public sealed record UpdateProductResponse(bool IsSuccess);

public class UpdateProductCommandEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPut("/products", async (UpdateProductRequest request, ISender Sender) =>
		{
			var command = request.Adapt<UpdateProductCommand>();

			var result = await Sender.Send(command);

			var response = result.Adapt<UpdateProductResponse>();

			return Results.Ok(response);
		})
			.WithName("UpdateProduct")
			.WithDescription("Update a product in the catalog")
			.WithSummary("Update a product")
			.Produces<UpdateProductRequest>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
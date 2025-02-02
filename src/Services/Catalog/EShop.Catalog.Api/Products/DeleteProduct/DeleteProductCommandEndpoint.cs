
namespace EShop.Catalog.Api.Products.DeleteProduct;

//public sealed record DeleteProductRequest(Guid ProductId)
public sealed record DeleteProductResponse(bool IsSuccess);

public class DeleteProductCommandEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapDelete("/products/{id}", async (Guid id, ISender sender) => 
		{ 
			var result = await sender.Send(new DeleteProductCommand(id));
			var response = result.Adapt<DeleteProductResponse>();
			return Results.Ok(new DeleteProductResponse(result.IsSuccess));

		})
			.WithName("DeleteProduct")
			.WithDescription("Delete a product by id")
			.WithSummary("Delete a product by id")
			.Produces<DeleteProductResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}	
}
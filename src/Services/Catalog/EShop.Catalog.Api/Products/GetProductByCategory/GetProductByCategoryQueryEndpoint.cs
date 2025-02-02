namespace EShop.Catalog.Api.Products.GetProductByCategory;

//public sealed record GetProductByCategoryRequest();
public sealed record GetProductsByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryQueryEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
		{
			var result = await sender.Send(new GetProductByCategoryQuery(category));
			var response = result.Adapt<GetProductsByCategoryResponse>();
			return Results.Ok(response);
		})
			.WithName("GetProductByCategory")
			.WithDescription("Get products by category")
			.WithSummary("Get products by category")
			.Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound);
	}
}
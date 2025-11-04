using Microsoft.AspNetCore.Mvc;

namespace EShop.Catalog.Api.Products.GetProducts;

public sealed record GetProductsRequest(
    [property: FromQuery(Name = "pagenumber")] int? PageNumber = null, 
    [property: FromQuery(Name = "pagesize")] int? PageSize = null);
public sealed record GetProductsResponse(IEnumerable<Product> Products);

public sealed class GetProductsQueryEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
		{
			var query = request.Adapt<GetProductsQuery>();
			var products = await sender.Send(query);
			var response = products.Adapt<GetProductsResponse>();
			return Results.Ok(response);
		})
			.WithName("GetProducts")
			.WithDescription("Get all products")
			.WithSummary("Get all products")
			.Produces<GetProductsResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.ProducesProblem(StatusCodes.Status400BadRequest);
	}
}
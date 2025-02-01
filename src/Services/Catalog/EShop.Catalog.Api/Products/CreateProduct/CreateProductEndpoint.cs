namespace EShop.Catalog.Api.Products.CreateProduct;

public sealed class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
		app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
		{
			var command = request.Adapt<CreateProductCommand>();
			var result = await sender.Send(command);
			var response = result.Adapt<CreateProductResponse>();

			return Results.Created($"products/{response.Id}", response);
		})
			.WithName("CreateProduct")
			.WithDescription("Create a new product in the catalog")
			.WithSummary("Create a new product")
			.Produces<CreateProductRequest>(StatusCodes.Status201Created)
			.ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
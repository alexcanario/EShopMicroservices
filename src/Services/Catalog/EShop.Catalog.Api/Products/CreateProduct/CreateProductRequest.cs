namespace EShop.Catalog.Api.Products.CreateProduct;

public sealed record CreateProductRequest(string Name, IList<string> Category, string Description, string ImageFile, decimal Price);

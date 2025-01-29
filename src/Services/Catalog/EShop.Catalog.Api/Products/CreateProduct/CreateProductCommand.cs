using EShop.BuildingBlocks.CQRS;

namespace EShop.Catalog.Api.Products.CreateProduct;

public sealed record CreateProductCommand(string Name, IList<string> Category, string Description, string ImageFile, decimal Price) 
    : ICommand<CreateProductResult>;
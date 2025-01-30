using EShop.BuildingBlocks.CQRS;
using EShop.Catalog.Api.Models;

namespace EShop.Catalog.Api.Products.CreateProduct;

internal sealed class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //Business Logic to Product Creation

        //Create product entity from command object
        var product = new Product
        {
            Name = request.Name,
            Category = request.Category,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Price = request.Price
        };

        //TODO
        //Save product entity to database
        //Return CreateProductResult with product id
    }
}
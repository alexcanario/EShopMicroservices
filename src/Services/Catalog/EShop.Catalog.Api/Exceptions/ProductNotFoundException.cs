using EShop.BuildingBlocks.Exceptions;

namespace EShop.Catalog.Api.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
	public ProductNotFoundException(Guid Id) : base("Product", Id) {}
}
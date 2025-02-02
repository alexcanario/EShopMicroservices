namespace EShop.Catalog.Api.Exceptions;

public sealed class ProductNotFoundException : Exception
{
	public ProductNotFoundException():base("Product not found!") {}
}
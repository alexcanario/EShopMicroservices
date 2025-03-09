namespace EShop.Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
	public string Name { get; private set; } = string.Empty;
	public decimal Price { get; private set; }

	public static Product Create(ProductId productId, string name, decimal price)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

		return new Product
		{
			Id = productId,
			Name = name,
			Price = price
		};
	}
}
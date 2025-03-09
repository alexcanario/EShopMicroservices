namespace EShop.Ordering.Domain.ValueObjects;

public record ProductId
{
	public Guid Value { get; }

	public ProductId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new ArgumentException("Product i, cannot be empty!", nameof(value));
		}
	}

	public static implicit operator Guid(ProductId productId) => productId.Value;
	public static implicit operator ProductId(Guid productId) => new(productId);
}
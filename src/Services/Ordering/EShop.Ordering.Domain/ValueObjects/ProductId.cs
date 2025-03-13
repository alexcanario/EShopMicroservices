namespace EShop.Ordering.Domain.ValueObjects;

public record ProductId
{
	public Guid Value { get; }
	private ProductId(Guid value) => Value = value;

	public static implicit operator Guid(ProductId productId) => productId.Value;
	public static implicit operator ProductId(Guid productId) => Of(productId);

	public static ProductId Of(Guid value)
	{
		if (value == Guid.Empty)
			throw new DomainException("Product i, cannot be empty!");

		return new ProductId(value);
	}
}
namespace EShop.Ordering.Domain.ValueObjects;

public record OrderId
{
	public Guid Value { get; }
	
	private OrderId(Guid value) => Value = value;

	public static implicit operator Guid(OrderId orderId) => orderId.Value;
	public static implicit operator OrderId(Guid orderId) => new(orderId);

	public static OrderId Of(Guid value)
	{
		if(value == Guid.Empty)
			throw new DomainException("Order id, cannot be empty!");

		return new(value);
	}
}
namespace EShop.Ordering.Domain.ValueObjects;

public record OrderItemId
{
	public Guid Value { get; }
	
	private OrderItemId(Guid value) => Value = value;

	public static implicit operator Guid(OrderItemId orderItemId) => orderItemId.Value;
	public static implicit operator OrderItemId(Guid orderItemId) => Of(orderItemId);

	public static OrderItemId Of(Guid value)
	{
		if (value == Guid.Empty)
			throw new DomainException("OrderItem id cannot be emtpty!");

		return new OrderItemId(value);
	}
}
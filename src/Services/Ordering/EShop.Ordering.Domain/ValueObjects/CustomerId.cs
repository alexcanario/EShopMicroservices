namespace EShop.Ordering.Domain.ValueObjects;

public record CustomerId
{
	public Guid Value { get; }
	
	private CustomerId(Guid value) => Value = value;

	public static implicit operator Guid(CustomerId customerId) => customerId.Value;
	public static implicit operator CustomerId(Guid customerId) => Of(customerId);

	public static CustomerId Of(Guid value)
    {
        return value == Guid.Empty ? throw new DomainException("Customer id cannot be empty.") : new CustomerId(value);
    }
}
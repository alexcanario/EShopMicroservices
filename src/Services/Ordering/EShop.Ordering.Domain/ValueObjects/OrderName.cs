using System.Net.Http.Headers;

namespace EShop.Ordering.Domain.ValueObjects;

public record OrderName
{
	public string Value { get; } = string.Empty;

	public OrderName(string value)
	{
		if(string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException("Order name cannot be empty", nameof(value));
		}
	}

	public static implicit operator string(OrderName orderName) => orderName.Value;
	public static implicit operator OrderName(string orderName) => new(orderName);
}
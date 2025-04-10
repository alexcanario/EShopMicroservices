namespace EShop.Ordering.Domain.ValueObjects;

public record OrderName
{
	private const int DefaultLength = 5;
	public string Value { get; }
	
	private OrderName(string value) => Value = value;

	//public static implicit operator string(OrderName orderName) => orderName.Value;
	//public static implicit operator OrderName(string orderName) => Of(orderName);

	/// <summary>
	/// Value for order name must be 5 characters long.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static OrderName Of(string value)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace("Order name cannot be empty!", nameof(value));
		ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength, $"Order name length must be {DefaultLength} characters!");

		return new OrderName(value);
	}
}
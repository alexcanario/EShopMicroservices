namespace EShop.Ordering.Domain.ValueObjects;

public record OrderName
{
    private const int MinLength = 3;    
    private const int MaxLength = 5;
    public string Value { get; }
	
	private OrderName(string value) => Value = value;

	//public static implicit operator string(OrderName orderName) => orderName.Value;
	//public static implicit operator OrderName(string orderName) => Of(orderName);

	/// <summary>
	/// Value for order name must be between 3 and 5 characters long.
	/// Value for order name must be between 3 and 5 characters long.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static OrderName Of(string value)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace("Order name cannot be empty!", nameof(value));
		ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, MinLength, $"Order name length must be greater then {MinLength} characters!");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength, $"Order name length must be {MaxLength} characters!");

		return new OrderName(value);
	}
}
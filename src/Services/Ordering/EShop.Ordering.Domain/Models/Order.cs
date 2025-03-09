namespace EShop.Ordering.Domain.Models;

public class Order : Aggregate<OrderId>
{
	private readonly IList<OrderItem> _orderItems = [];
	public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

	public CustomerId CustomerId { get; private set; } = default!;
	public string OrderName { get; private set; } = string.Empty;
	public Address ShippingAddress { get; private set; } = default!;
	public Address BillingAddress { get; private set; } = default!;
	public Payment Payment { get; private set; } = default!;
	public OrderStatus Status { get; private set; } = OrderStatus.Pending;
	public decimal TotalPrice => _orderItems.Sum(x => x.UnitPrice * x.Quantity);
}
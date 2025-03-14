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

	public static Order Create(OrderId orderId, CustomerId customerId, OrderName orderName, 
		Address shippingAddress, Address billingAddres, Payment payment, OrderStatus status)
	{
		var order = new Order
		{
			Id = orderId,
			CustomerId = customerId,
			OrderName = orderName,
			ShippingAddress = shippingAddress,
			BillingAddress = billingAddres,
			Payment = payment,
			Status = status
		};

		order.AddDomainEvent(new OrderCreatedDomainEvent(order));

		return order;
	}

	public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
	{
		OrderName = orderName;
		ShippingAddress = shippingAddress;
		BillingAddress = billingAddress;
		Payment = payment;
	}
}
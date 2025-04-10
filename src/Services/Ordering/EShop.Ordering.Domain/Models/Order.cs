namespace EShop.Ordering.Domain.Models;

public class Order : Aggregate<OrderId>
{
	private readonly IList<OrderItem> _orderItems = [];
	public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

	public CustomerId CustomerId { get; private set; } = null!;
	public OrderName OrderName { get; private set; } = null!;
	public Address ShippingAddress { get; private set; } = null!;
	public Address BillingAddress { get; private set; } = null!;
	public Payment Payment { get; private set; } = null!;
	public OrderStatus Status { get; private set; } = OrderStatus.Pending;
	public decimal TotalPrice
	{
		get => _orderItems.Sum(x => x.UnitPrice * x.Quantity);
		private set { }
	}

	public static Order Create(OrderId orderId, CustomerId customerId, OrderName orderName, 
		Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status = OrderStatus.Pending)
	{
		var order = new Order
		{
			Id = orderId,
			CustomerId = customerId,
			OrderName = orderName,
			ShippingAddress = shippingAddress,
			BillingAddress = billingAddress,
			Payment = payment,
			Status = status
		};

		order.AddDomainEvent(new OrderCreatedEvent(order));

		return order;
	}

	public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
	{
		OrderName = orderName;
		ShippingAddress = shippingAddress;
		BillingAddress = billingAddress;
		Payment = payment;
		Status = status;

		AddDomainEvent(new OrderUpdatedEvent(this));
	}

	public void AddOrderItem(ProductId productId, int quantity, decimal unitPrice)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(unitPrice, nameof(unitPrice));

		var orderItem = new OrderItem(Id, productId, unitPrice, quantity);

		_orderItems.Add(orderItem);
	}

	public void RemoveOrderItem(OrderItemId orderItemId)
	{
		ArgumentNullException.ThrowIfNull(orderItemId, $"Item to remove can not be null, {nameof(orderItemId)}");
		
		var orderITem = _orderItems.FirstOrDefault(_ => _.Id == orderItemId);
		ArgumentNullException.ThrowIfNull(orderITem, $"Item to remove not found, {nameof(orderItemId)}");

		_orderItems.Remove(orderITem);
	}
}
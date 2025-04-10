namespace EShop.Ordering.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
	internal OrderItem(OrderId orderId, ProductId productId, decimal unitPrice, int quantity)
	{
		Id = OrderItemId.Of(Guid.NewGuid());
		OrderId = orderId;
		ProductId = productId;
		UnitPrice = unitPrice;
		Quantity = quantity;
	}

	public OrderId OrderId { get; private set; }
	public ProductId ProductId { get; private set; }
	public int Quantity { get; private set; } = 0;
	public decimal UnitPrice { get; private set; } = 0M;

	public virtual Order? Order { get; private set; }
}
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

	public OrderId OrderId { get; private set; } = default!;
	public ProductId ProductId { get; private set; } = default!;
	public int Quantity { get; private set; } = default!;
	public decimal UnitPrice { get; private set; } = default!;
}
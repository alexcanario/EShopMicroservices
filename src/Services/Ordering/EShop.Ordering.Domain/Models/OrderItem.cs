namespace EShop.Ordering.Domain.Models;

public class OrderItem(OrderId orderId, ProductId productId, decimal unitPrice, int quantity) : Entity<Guid>
{
	public OrderId OrderId { get; private set; } = orderId;
	public ProductId ProductId { get; private set; } = productId;
	public decimal UnitPrice { get; private set; } = unitPrice;
	public int Quantity { get; private set; } = quantity;
}
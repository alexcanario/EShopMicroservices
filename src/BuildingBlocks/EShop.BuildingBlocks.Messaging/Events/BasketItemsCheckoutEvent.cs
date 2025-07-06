namespace EShop.BuildingBlocks.Messaging.Events;

public sealed record BasketItemsCheckoutEvent
{
	public Guid ProductId { get; set; }
	public string ProductName { get; set; } = string.Empty;
	public decimal Price { get; set; } = decimal.Zero;
	public int Quantity { get; set; } = -1;
}
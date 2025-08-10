namespace EShop.BuildingBlocks.Messaging.Events;

public sealed record BasketItemsCheckoutEvent
{
	public Guid ProductId { get; set; } = Guid.Empty;
	public string ProductName { get; set; } = string.Empty;
	public decimal Price { get; set; } = decimal.MinusOne;
	public int Quantity { get; set; } = -1;
}
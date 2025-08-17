namespace EShop.Basket.API.DataTransfers;

public sealed record BasketItemsCheckoutDto
{
	public Guid ProductId { get; set; } = Guid.Empty;
    public int Quantity { get; set; } = 0;
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
}
namespace EShop.Basket.API.Models;

public sealed class ShoppingCartItem
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public int Quantity { get; set; } = 0;
	public string ProductName { get; set; } = string.Empty!;
	public decimal Price { get; set; } = decimal.Zero;
	public string Color { get; set; } = string.Empty!;
}
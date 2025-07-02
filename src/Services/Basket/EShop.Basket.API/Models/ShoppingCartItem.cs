namespace EShop.Basket.API.Models;

public sealed class ShoppingCartItem
{
	public int Quantity { get; set; } = default;
	public Guid ProductId { get; set; } = default;
	public string ProductName { get; set; } = string.Empty!;
	public decimal Price { get; set; } = default;
	public string Color { get; set; } = string.Empty!;
}
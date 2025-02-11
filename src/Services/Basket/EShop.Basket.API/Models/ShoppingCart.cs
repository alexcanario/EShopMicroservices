namespace EShop.Basket.API.Models;

public sealed class ShoppingCart
{
	public ShoppingCart() { }
	public ShoppingCart(string username) => Username = username;

	public string Username { get; set; } = default!;
	public IList<ShoppingCartItem> Items { get; set; } = [];
	public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}
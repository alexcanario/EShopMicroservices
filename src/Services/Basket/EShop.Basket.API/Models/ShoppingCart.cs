namespace EShop.Basket.API.Models;

public sealed class ShoppingCart
{
	public ShoppingCart() { }
	public ShoppingCart(string username) => Username = username;

	public string Username { get; private set; } = string.Empty;
	public IList<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
	public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}
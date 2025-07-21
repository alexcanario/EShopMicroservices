using System.Text.Json.Serialization;

namespace EShop.Basket.API.Models;

public sealed class ShoppingCart
{
    [JsonConstructor]
    public ShoppingCart() { }
    
	public ShoppingCart(string username) => Username = username;

	public string Username { get; set; } = string.Empty;
	public IList<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
	public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
}
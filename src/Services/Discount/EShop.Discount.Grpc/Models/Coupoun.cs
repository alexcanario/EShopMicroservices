namespace EShop.Discount.Grpc.Models;

public class Coupoun
{
	public int Id { get; set; }
	public string ProductName { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int Amount { get; set; }
}
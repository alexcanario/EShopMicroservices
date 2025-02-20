namespace EShop.Discount.Grpc.Models;

public class Cupoun
{
	public int Id { get; set; }
	public string ProductName { get; set; } = default!;
	public string Description { get; set; } = default!;
	public int Amount { get; set; }
}
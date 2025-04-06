namespace EShop.Ordering.Infra.Data.Extensions;

internal class InitialData
{
	public static IEnumerable<Customer> Customers =>
		new List<Customer>
		{
			Customer.Create(CustomerId.Of(new Guid("B8490294-9306-4317-A0FF-C2C4BCEBA3CE")), "Alex Canario", "alexcanario@gmail.com"),
			Customer.Create(CustomerId.Of(new Guid("9E0F8206-9E29-47EB-B308-FCD54DD929DE")), "Fernanda Canario", "nandacanario@gmail.com"),
		};

	public static IEnumerable<Product> Products =>
		new List<Product>
		{
			Product.Create(ProductId.Of(new Guid("51BA242A-39A2-433C-87F1-29FF7FAE3D45")), "Samsung S10 Ultra 256gb", 1100M),
			Product.Create(ProductId.Of(new Guid("776CA130-C994-496B-949D-1AB660B907EF")), "Samsung S10 Ultra 512gb", 1200M),
			Product.Create(ProductId.Of(new Guid("B32E9B95-B7BC-4D84-BB0C-2E69F8A988CA")), "Samsung S10 Ultra 1024gb", 1400M),
			Product.Create(ProductId.Of(new Guid("F11A2C4D-D80F-42BD-AFE2-0175104AC99C")), "Iphone 16 256gb", 900M),
		};

	public static IEnumerable<Order> OrdersWithItems
	{
		get
		{
			var address1 = Address.Of("alex", "canario", "alexcanario@gmail.com", "rua tilias, 40", "portugal", "se", "2855-268");
			var address2 = Address.Of("fernanda", "canario", "alexcanario@gmail.com", "rua tilias, 40", "portugal", "se", "2855-268");
			var payment1 = Payment.Of("will", "1111222233334444", "03/32", "133", "credit");
			var payment2 = Payment.Of("nbank", "222233334444555", "03/35", "128", "credit");

			#region Order1 Creation

			var order1 = Order.Create(
				OrderId.Of(new Guid("A4D3E5F2-0C8B-4E7A-8F6C-9D3B5F1A2E7D")),
				CustomerId.Of(new Guid("B8490294-9306-4317-A0FF-C2C4BCEBA3CE")),
				OrderName.Of("Order 1"),
				shippingAddress: address1,
				billingAddress: address1,
				payment1);

			order1.AddOrderItem(ProductId.Of(new Guid("51BA242A-39A2-433C-87F1-29FF7FAE3D45")), 1, 1100M);
			order1.AddOrderItem(ProductId.Of(new Guid("776CA130-C994-496B-949D-1AB660B907EF")), 2, 1200M);
			#endregion Order1 Creation

			#region Order2 Creation

			var order2 = Order.Create(
				OrderId.Of(new Guid("A4D3E5F2-0C8B-4E7A-8F6C-9D3B5F1A2E7D")),
				CustomerId.Of(new Guid("9E0F8206-9E29-47EB-B308-FCD54DD929DE")),
				OrderName.Of("Order 2"),
				shippingAddress: address2,
				billingAddress: address2,
				payment2);

			order2.AddOrderItem(ProductId.Of(new Guid("B32E9B95-B7BC-4D84-BB0C-2E69F8A988CA")), 1, 1300M);
			order2.AddOrderItem(ProductId.Of(new Guid("F11A2C4D-D80F-42BD-AFE2-0175104AC99C")), 2, 900M);
			#endregion
			
			return new List<Order>
			{
				order1,
				order2
			};
		}
	}
}
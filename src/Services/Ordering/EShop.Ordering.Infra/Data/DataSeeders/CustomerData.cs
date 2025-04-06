namespace EShop.Ordering.Infra.Data.DataSeeders;

public static class CustomerData
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>().HasData(InitialCustomers());
	}

	private static IList<Customer> InitialCustomers()
	{
		return new List<Customer>()
		{
			Customer.Create(CustomerId.Of(Guid.Parse("BD58EBFC-36D3-4339-A37A-A0D84E095C06")), "Alex Canario", "alexcanario@gmail.com"),
			Customer.Create(CustomerId.Of(Guid.Parse("758F8D2F-F592-400F-9DCC-8475AAE0F74D")), "Fernanda Canario", "nandacanario@gmail.com"),
		};
	}
}
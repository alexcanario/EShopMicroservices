namespace EShop.Ordering.Infra.Data.DataSeeders;

public static class InitialData
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		CustomerData.Seed(modelBuilder);
	}
}
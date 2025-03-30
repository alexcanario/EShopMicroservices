using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EShop.Ordering.Infra.Data;

public class OrderingDbContextFactory : IDesignTimeDbContextFactory<OrderingDbContext>
{
	public OrderingDbContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var optionsBuilder = new DbContextOptionsBuilder<OrderingDbContext>();
		var connectionString = configuration.GetConnectionString("OrderingConnection");

		optionsBuilder.UseSqlServer(connectionString);

		return new OrderingDbContext(optionsBuilder.Options);
	}
}
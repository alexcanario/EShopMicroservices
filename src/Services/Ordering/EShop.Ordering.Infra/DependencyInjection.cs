using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Ordering.Infra;

public static class DependencyInjection
{
	public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("OrderingConnection");

		//services.AddDbContext
		//services.AddScoped<IOrderingDbContext, OrderingDbContext>();

		return services;
	}
}
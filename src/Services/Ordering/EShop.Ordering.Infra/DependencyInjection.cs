using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Ordering.Infra;

public static class DependencyInjection
{
	public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
	{
		var orderingConnStr = configuration.GetConnectionString("OrderingConnection");
		services.AddDbContext<OrderingDbContext>(opt=> opt.UseSqlServer(orderingConnStr));

		services.AddScoped<I>

		return services;
	}
}
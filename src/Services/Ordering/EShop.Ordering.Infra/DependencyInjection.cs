using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Ordering.Infra;

public static class DependencyInjection
{
	public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
	{
        var orderingConnStr = configuration.GetConnectionString("OrderingConnection");
        services.AddDbContext<OrderingDbContext>((sp, opt) =>
        {
            opt.AddInterceptors((sp.GetServices<ISaveChangesInterceptor>()));
            opt.UseSqlServer(orderingConnStr);
        });

        return services;
	}
}
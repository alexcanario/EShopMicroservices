using EShop.Ordering.App.Data;

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Ordering.Infra;

public static class DependencyInjection
{
	public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
	{
        var orderingConnStr = configuration.GetConnectionString("OrderingConnection");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
		services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

		services.AddDbContext<OrderingDbContext>((sp, opt) =>
        {
            opt.AddInterceptors(sp.GetService<ISaveChangesInterceptor>()!);
			opt.UseSqlServer(orderingConnStr);
        });

		services.AddScoped<IOrderingDbContext, OrderingDbContext>();

        return services;
	}
}
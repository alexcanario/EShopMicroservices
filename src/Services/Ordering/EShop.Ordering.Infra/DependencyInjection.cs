using EShop.Ordering.App.Data;

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("OrderingDbContext");

            logger.LogInformation("OrderingDbContext connection string: {ConnectionString}", orderingConnStr);
            
            opt.AddInterceptors(sp.GetService<ISaveChangesInterceptor>()!);
            opt.UseSqlServer(orderingConnStr);
            opt.UseLoggerFactory(loggerFactory);
            opt.EnableSensitiveDataLogging();
            opt.LogTo(message => logger.LogInformation("{LogMessage}", message), LogLevel.Information);
        });

        services.AddScoped<IOrderingDbContext, OrderingDbContext>();

        return services;
    }
}
using EShop.BuildingBlocks.Exceptions.Handler;

using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace EShop.Ordering.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCarter();

		services.AddExceptionHandler<CustomExceptionHandler>();

		services.AddHealthChecks()
			.AddSqlServer(configuration.GetConnectionString("OrderingConnection") ?? string.Empty);
		
		return services;
	}

	public static IApplicationBuilder UseApiServices(this WebApplication app)
	{
		app.MapCarter();

		app.UseExceptionHandler(options => {});

		app.UseHealthChecks("/health", new HealthCheckOptions
		{
			ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
		});

		return app;
	}
}
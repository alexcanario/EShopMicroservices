using EShop.BuildingBlocks.Exceptions.Handler;

namespace EShop.Ordering.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services)
	{
		services.AddCarter();

		services.AddExceptionHandler<CustomExceptionHandler>();
		
		return services;
	}

	public static IApplicationBuilder UseApiServices(this WebApplication app)
	{
		app.MapCarter();

		app.UseExceptionHandler(options => {});

		return app;
	}
}
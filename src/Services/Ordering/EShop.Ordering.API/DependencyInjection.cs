using EShop.BuildingBlocks.Behaviors;

using System.Reflection;

namespace EShop.Ordering.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services)
	{
		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
			configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
			configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
		});

		return services;
	}

	public static WebApplication UseApiServices(this WebApplication app)
	{
		return app;
	}
}
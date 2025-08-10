using Microsoft.FeatureManagement;

namespace EShop.Ordering.App;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
	{
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(assembly);
			cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
			cfg.AddOpenBehavior(typeof(LoggingBehavior<,>)); 

		});

		services.AddFeatureManagement();
		services.AddMessageBroker(configuration, assembly);

		return services;
	}
}
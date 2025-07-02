using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace EShop.BuildingBlocks.Messaging.MassTransit;

public static class Extensions
{
	public static IServiceCollection AddMassTransitIntegrationEvents(
		this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
	{
		services.AddMassTransit(config =>
		{
			config.SetKebabCaseEndpointNameFormatter();

			config.AddConsumers(assembly ?? Assembly.GetExecutingAssembly());

			config.UsingRabbitMq((context, cfg) =>
			{
				var host = configuration["MessageBroker:RabbitMQ:host"]!;
				var port = configuration["MessageBroker:RabbitMQ:Port"]!;
				var uri = new Uri($"{host}:{port}");

				cfg.Host(uri, hostConfig =>
				{
					hostConfig.Username(configuration["MessageBroker:RabbitMQ:UserName"]!);
					hostConfig.Password(configuration["MessageBroker:RabbitMQ:Password"]!);
				});
				cfg.ConfigureEndpoints(context);
			});
		});
		return services;
	}
}
using Microsoft.FeatureManagement;

namespace EShop.Ordering.App.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, ILogger<OrderCreatedEventHandler> logger, IFeatureManager featureManager) 
	: INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent}", domainEvent.GetType().Name);

        if (await featureManager.IsEnabledAsync("PublishIntegrationEvents", cancellationToken))
        {
            var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto();
			
            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
			
            logger.LogInformation("Integration event published: {IntegrationEvent}", orderCreatedIntegrationEvent.GetType().Name);
		}
	}
}
namespace EShop.Ordering.App.Orders.EventHandlers;

public class OrderCreateEventHandler(ILogger<OrderCreateEventHandler> logger) 
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
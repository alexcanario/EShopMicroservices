namespace EShop.Ordering.App.Orders.EventHandlers;

public class UpdateOrderEventHandler(ILogger<UpdateOrderEventHandler> logger)
    : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
namespace EShop.Ordering.Domain.Events;

public record OrderUpdatedEvent(Order Order) : IDomainEvent;
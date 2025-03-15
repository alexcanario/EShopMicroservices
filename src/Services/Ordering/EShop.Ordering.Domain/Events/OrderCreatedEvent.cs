namespace EShop.Ordering.Domain.Events;

public record OrderCreatedEvent(Order order) : IDomainEvent;
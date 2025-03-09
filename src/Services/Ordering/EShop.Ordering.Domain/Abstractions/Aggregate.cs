namespace EShop.Ordering.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
	private readonly List<IDomainEvent> _domainEvents = [];
	public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

	public IDomainEvent[] ClearDomainEvents()
	{
		var dequeued = _domainEvents.ToArray();
		_domainEvents.Clear();

		return dequeued;
	}
}
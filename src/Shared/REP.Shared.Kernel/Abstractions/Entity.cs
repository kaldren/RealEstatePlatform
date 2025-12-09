
namespace REP.Shared.Kernel.Abstractions;

public abstract class Entity : IEntity
{
    // You can see the events but you cannot modify the collection directly from outside.
    public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    // CreatedAt property to track when the entity was created
    public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.UtcNow;

    // Method to clear domain events after they have been dispatched
    protected void ClearDomainEvents()
    {
        DomainEvents.Clear();
    }

    // Method to add a domain event (Note: This method is protected to ensure that only derived classes can add events)
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }
}

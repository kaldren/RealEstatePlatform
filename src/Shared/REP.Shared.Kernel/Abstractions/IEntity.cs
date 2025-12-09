namespace REP.Shared.Kernel.Abstractions;

public interface IEntity
{
    ICollection<IDomainEvent> DomainEvents { get; }
}

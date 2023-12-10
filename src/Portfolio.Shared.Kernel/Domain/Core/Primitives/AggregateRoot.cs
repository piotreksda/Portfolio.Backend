using Portfolio.Shared.Kernel.Application.Abstractions;

namespace Portfolio.Shared.Kernel.Domain.Core.Primitives;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}
//todo: inprogress
public abstract class AggregateRoot<T> : BaseAuditableEntity<T>, IAggregateRoot where T : struct
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public AggregateRoot()
    {
        
    }
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
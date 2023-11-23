using Portfolio.Domain.Core.Domain.Core.Primitives;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IDomainEventCollector
{
    IEnumerable<IAggregateRoot> GetAggregatesWithDomainEvents();
}
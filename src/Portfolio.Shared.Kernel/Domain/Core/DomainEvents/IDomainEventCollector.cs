using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IDomainEventCollector
{
    IEnumerable<IAggregateRoot> GetAggregatesWithDomainEvents();
}
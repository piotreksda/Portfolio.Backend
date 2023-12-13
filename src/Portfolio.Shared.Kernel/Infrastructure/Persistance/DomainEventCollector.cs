using Portfolio.Shared.Kernel.Domain;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Persistance;

public sealed class DomainEventCollector(PortfolioDbContext dbContext) : IDomainEventCollector
{
    public IEnumerable<IAggregateRoot> GetAggregatesWithDomainEvents()
    {
        return dbContext.ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);
    }
}
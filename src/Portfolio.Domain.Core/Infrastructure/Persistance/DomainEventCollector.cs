using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain;
using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Infrastructure.EntityFramework;

namespace Portfolio.Domain.Core.Infrastructure.Persistance;

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
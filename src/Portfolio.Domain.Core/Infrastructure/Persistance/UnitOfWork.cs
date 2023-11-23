using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain;
using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Infrastructure.EntityFramework;

namespace Portfolio.Domain.Core.Infrastructure.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly PortfolioDbContext _dbContext;

    public UnitOfWork(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        if (_dbContext.ChangeTracker.Entries<IAggregateRoot>().Any(e => e.Entity.DomainEvents.Any()))
        {
            throw new InvalidOperationException("Domain events must be handled before committing the UnitOfWork.");
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
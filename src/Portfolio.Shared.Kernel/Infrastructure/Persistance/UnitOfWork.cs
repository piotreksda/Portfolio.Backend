using Portfolio.Shared.Kernel.Domain;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Persistance;

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
using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Kernel.Domain;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Repositories;

public abstract class RootRepository<T, T2> : IRootRepository<T, T2> where T : BaseEntity<T2> where T2 : struct
{
    protected readonly PortfolioDbContext _dbContext;

    protected RootRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(T2 id)
    {
        return await _dbContext.Set<T>().SingleOrDefaultAsync();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public Task Remove(T entity)
    {
        entity.Delete();
        return Task.CompletedTask;
    }

    public Task Update(T entity)
    {
        _dbContext.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }
    public Task Update(IEnumerable<T> entities)
    {
        foreach (T entity in entities)
        {
            Update(entity);
        }

        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IRootRepository<T, in T2> where T : BaseEntity<T2> where T2 : struct
{
    
    Task<T?> GetByIdAsync(T2 id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task Remove(T entity);
    Task Update(T entity);
    Task Update(IEnumerable<T> entities);
    public Task SaveChangesAsync();
}
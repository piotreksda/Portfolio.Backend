using Portfolio.Domain.Core.Domain.Core.Primitives;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IRootRepository<T, in T2> where T : BaseEntity<T2> where T2 : struct
{
    
    Task<T?> GetByIdAsync(T2 id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task Remove(T entity);
    Task Update(T entity);
    Task Update(IEnumerable<T> entities);
}
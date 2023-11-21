using Portfolio.Domain.Core.Domain.Core.Primitives;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IRootRepository<T, in T2> where T : BaseEntity<T2> where T2 : struct
{
    
    Task<T?> GetById(T2 id);
    Task<T?> GetByIdToEdit(T2 id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Remove(T entity);
}
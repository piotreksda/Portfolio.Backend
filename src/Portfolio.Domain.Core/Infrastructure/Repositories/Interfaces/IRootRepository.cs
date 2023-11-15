using Portfolio.Domain.Core.Domain.Entites;
using Portfolio.Domain.Core.Domain.Primitives;

namespace Portfolio.Domain.Core.Infrastructure.Repositories.Interfaces;

public interface IRootRepository<T, in T2> where T : BaseEntity<T2> where T2 : struct
{
    
    Task<T> GetById(T2 id);
    Task<T> GetByIdToEdit(T2 id);
    Task<IEnumerable<T>> GetAll();
    Task Add();
    Task Remove();
}
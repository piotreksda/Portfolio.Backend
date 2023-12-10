using Portfolio.Shared.Kernel.Domain.Dictionary.Entities;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface ITranslationRepository<T,in T2> : IRootRepository<T,T2> where T : BaseEntity<T2> where T2 : struct
{
    
}
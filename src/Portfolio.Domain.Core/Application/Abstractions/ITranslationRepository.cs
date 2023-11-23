using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Dictionary.Entities;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface ITranslationRepository<T,in T2> : IRootRepository<T,T2> where T : BaseEntity<T2> where T2 : struct
{
    
}
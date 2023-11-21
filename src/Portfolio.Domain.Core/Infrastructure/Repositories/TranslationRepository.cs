using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain.Dictionary.Entities;

namespace Portfolio.Domain.Core.Infrastructure.Repositories;

public class TranslationRepository : ITranslationRepository
{
    public async Task<Translation?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Translation?> GetByIdToEdit(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Translation>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task Add(Translation entity)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(Translation entity)
    {
        throw new NotImplementedException();
    }
}
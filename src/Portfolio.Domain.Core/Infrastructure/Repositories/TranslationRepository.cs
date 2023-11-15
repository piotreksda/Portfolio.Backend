using Portfolio.Domain.Core.Domain.Dictionary.Entities;
using Portfolio.Domain.Core.Infrastructure.Repositories.Interfaces;

namespace Portfolio.Domain.Core.Infrastructure.Repositories;

public class TranslationRepository : IRootRepository<Translation, Guid>
{
    public async Task<Translation> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Translation> GetByIdToEdit(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Translation>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task Add()
    {
        throw new NotImplementedException();
    }

    public async Task Remove()
    {
        throw new NotImplementedException();
    }
}
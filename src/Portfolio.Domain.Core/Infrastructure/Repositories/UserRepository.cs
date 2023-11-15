using Portfolio.Domain.Core.Domain.Auth.Entities;
using Portfolio.Domain.Core.Infrastructure.Repositories.Interfaces;

namespace Portfolio.Domain.Core.Infrastructure.Repositories;

public class UserRepository : IRootRepository<ApplicationUser, int>
{
    public async Task<ApplicationUser> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser> GetByIdToEdit(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ApplicationUser>> GetAll()
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
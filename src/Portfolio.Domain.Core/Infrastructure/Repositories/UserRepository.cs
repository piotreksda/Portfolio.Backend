using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain;
using Portfolio.Domain.Core.Domain.Auth.Entities;

namespace Portfolio.Domain.Core.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PortfolioDbContext _context;

    public UserRepository(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> GetById(int id)
    {
        return await _context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ApplicationUser?> GetByIdToEdit(int id)
    {
        return await _context.Users
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ApplicationUser>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task Add(ApplicationUser entity)
    {
        await _context.Users.AddAsync(entity);
    }

    public async Task Remove(ApplicationUser entity)
    {
        entity.Delete();
    }
}
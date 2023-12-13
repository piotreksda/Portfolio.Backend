using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Repositories;

public class UserRepository : RootRepository<ApplicationUser, int>, IUserRepository
{
    public UserRepository(PortfolioDbContext dbContext) : base(dbContext)
    {
    }

    public new async Task<ApplicationUser?> GetByIdAsync(int id)
    {
        return await _dbContext.Users
            .Include(x => x.UsersRoles)
                .ThenInclude(x => x.Role)
                    .ThenInclude(x => x.RolesPermissionSets)
                        .ThenInclude(x => x.PermissionSet)
                            .ThenInclude(x => x.PermissionPermissionSet)
                                .ThenInclude(x => x.Permission)
            .Include(x => x.RefreshTokens)
            .Include(x => x.LoginHistories)
            .SingleOrDefaultAsync(x => x.Id == id);

    }

    public async Task<bool> CheckIfEmailIsUsed(Email email)
    {
        return _dbContext.Users.Any(x => x.Email.Value == email);
    }

    public async Task<bool> CheckIfUserNameIsUsed(string userName)
    {
        return _dbContext.Users.Any(x => x.UserName == userName);
    }

    public async Task<bool> CheckIfUserNameOrEmailIsUsed(Email email, string userName)
    {
        return await _dbContext.Users.AnyAsync(x => x.UserName == userName || x.Email.Value == email);
    }

    public async Task<ApplicationUser?> GetUserByUserNameOrEmail(string value)
    {
        return await _dbContext.Users
            .Include(x => x.UsersRoles)
                .ThenInclude(x => x.Role)
                    .ThenInclude(x => x.RolesPermissionSets)
                        .ThenInclude(x => x.PermissionSet)
                            .ThenInclude(x => x.PermissionPermissionSet)
                                .ThenInclude(x => x.Permission)
            .Include(x => x.RefreshTokens)
            .Include(x => x.LoginHistories)
            .SingleOrDefaultAsync(x => x.UserName == value || x.Email.Value == value);
    }
}
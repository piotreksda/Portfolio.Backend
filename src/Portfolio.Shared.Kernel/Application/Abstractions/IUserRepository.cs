using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IUserRepository : IRootRepository<ApplicationUser, int>
{
    Task<bool> CheckIfEmailIsUsed(Email email);
    Task<bool> CheckIfUserNameIsUsed(string userName);
    Task<bool> CheckIfUserNameOrEmailIsUsed(Email email, string userName);
    Task<ApplicationUser?> GetUserByUserNameOrEmail(string value);
}
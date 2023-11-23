using Portfolio.Domain.Core.Domain.Auth.Entities;
using Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IUserRepository : IRootRepository<ApplicationUser, int>
{
    Task<bool> CheckIfEmailIsUsed(Email email);
    Task<bool> CheckIfUserNameIsUsed(string userName);
    Task<ApplicationUser?> GetUserByUserNameOrEmail(string value);
}
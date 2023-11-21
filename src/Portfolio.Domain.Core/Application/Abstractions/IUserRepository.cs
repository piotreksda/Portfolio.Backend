using Portfolio.Domain.Core.Domain.Auth.Entities;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IUserRepository : IRootRepository<ApplicationUser, int>
{
    
}
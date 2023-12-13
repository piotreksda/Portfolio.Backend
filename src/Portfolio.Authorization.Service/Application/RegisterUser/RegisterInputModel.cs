using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;

namespace Portfolio.Authorization.Service.Application.RegisterUser;

public record RegisterInputModel
{
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
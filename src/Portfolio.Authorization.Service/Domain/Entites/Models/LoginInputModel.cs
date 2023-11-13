namespace Portfolio.Authorization.Service.Domain.Entites.Models;

public record LoginInputModel
{
    public string Login { get; init; } = String.Empty;
    public string Password { get; init; } = String.Empty;
}

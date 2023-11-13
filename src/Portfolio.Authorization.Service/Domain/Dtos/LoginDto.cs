namespace Portfolio.Authorization.Service.Domain.Dtos;

public record LoginDto
{
    public int UserId { get; init; }
    public string Token { get; init; } = String.Empty;
    public string RefreshToken { get; init; } = String.Empty;

}

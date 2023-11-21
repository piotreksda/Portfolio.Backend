namespace Portfolio.Authorization.Service.Application.LoginUser;

public record LoginInputModel
{
    public string Login { get; init; } = String.Empty;
    public string Password { get; init; } = String.Empty;
    
    public string? TwoFaCode { get; init; }
    
}

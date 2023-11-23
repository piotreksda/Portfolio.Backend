using System.IdentityModel.Tokens.Jwt;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IIdentityContext
{
    int? UserId { get; }
    string? TokenString { get; }
    JwtSecurityToken Token { get; }
    List<string> Permissions { get; }
    
    Task Configure(string tokenString);
}
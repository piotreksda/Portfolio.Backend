using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IJwtTokenService
{
    bool CheckIfTokenIsValid(string token);
    Task<IEnumerable<Claim>> CheckIfTokenIsValidAndReturnCalms(string token, string? key = null);
    string GetTokenFromContext(HttpContext context);
    Task<JwtSecurityToken> CreateTokenForUser(ApplicationUser user);

}

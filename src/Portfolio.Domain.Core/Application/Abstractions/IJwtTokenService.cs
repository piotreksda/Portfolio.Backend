using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Portfolio.Domain.Core.Domain.Auth.Entities;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IJwtTokenService
{
    bool CheckIfTokenIsValid(string token);
    Task<IEnumerable<Claim>> CheckIfTokenIsValidAndReturnCalms(string token);
    string GetTokenFromContext(HttpContext context);
    Task<JwtSecurityToken> CreateTokenForUser(ApplicationUser user);

}

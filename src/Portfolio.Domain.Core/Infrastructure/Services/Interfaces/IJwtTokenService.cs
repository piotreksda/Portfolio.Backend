using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Portfolio.Domain.Core.Infrastructure.Services.Interfaces;

public interface IJwtTokenService
{
    bool CheckIfTokenIsValid(string token);
    Task<IEnumerable<Claim>> CheckIfTokenIsValidAndReturnCalms(string token);
    string GetTokenFromContext(ActionExecutingContext context);

}

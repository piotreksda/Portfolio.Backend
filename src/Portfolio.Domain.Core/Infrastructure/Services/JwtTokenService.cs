using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Portfolio.Domain.Core.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Portfolio.Domain.Core.Infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly IAuthenticationService _authenticationService;
    public JwtTokenService(IConfiguration configuration, IAuthenticationService authenticationService)
    {
        _configuration = configuration;
        _authenticationService = authenticationService;
    }
    public bool CheckIfTokenIsValid(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Claim>> CheckIfTokenIsValidAndReturnCalms(string token)
    {
        string defaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        AuthenticateResult authenticationResult = await _authenticationService.AuthenticateAsync(new DefaultHttpContext(), defaultAuthenticateScheme);

        if (!authenticationResult.Succeeded)
        {
            throw GetAuthenticationException(authenticationResult.Failure);
        }

        return authenticationResult.Principal.Claims;
    }

    private Exception GetAuthenticationException(Exception? exception)
    {
        return exception switch 
        {
            SecurityTokenExpiredException => new TokenExpiredException(),
            SecurityTokenValidationException => new TokenValidationException(),
            null =>  new ForbiddenException(),
            _ => new ForbiddenException()
        };
    }

    public string GetTokenFromContext(ActionExecutingContext context)
    {
        bool tokenIsInHeaders = context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);

        if (string.IsNullOrEmpty(token) && !tokenIsInHeaders)
        {
            throw new Exception();//401 token not in headers exception
        }

        return token;
    }
}

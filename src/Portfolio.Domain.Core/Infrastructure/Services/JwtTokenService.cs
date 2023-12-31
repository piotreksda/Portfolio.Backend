﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain.Auth.Entities;
using Portfolio.Domain.Core.Domain.Constants;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;
using Portfolio.Domain.Core.Domain.Core.Exceptions.NotFoundExceptions;
using Portfolio.Domain.Core.Domain.Core.Exceptions.UnauthorizedExceptions;

namespace Portfolio.Domain.Core.Infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public bool CheckIfTokenIsValid(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<JwtSecurityToken> CreateTokenForUser(ApplicationUser user)
    {

        
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var permissionList = user.GetPermissionsList();
            var claims = GetClaims(user, permissionList);
            return CreateJwtToken(claims);
    }

    private List<Claim> GetClaims(ApplicationUser user, IEnumerable<string> permissionList)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
        };

        claims.AddRange(permissionList.Select(permission => 
            new Claim(ClaimsTypes.PermissionListClaim, permission)));

        return claims;
    }

    private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        return new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );
    }
    

    public async Task<IEnumerable<Claim>> CheckIfTokenIsValidAndReturnCalms(string token)
    {
        // string defaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        // AuthenticateResult authenticationResult = await _authenticationService.AuthenticateAsync(new DefaultHttpContext(), defaultAuthenticateScheme);
        //
        // if (!authenticationResult.Succeeded)
        // {
        //     throw GetAuthenticationException(authenticationResult.Failure);
        // }
        //
        // return authenticationResult.Principal.Claims;
        return null;
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

    public string GetTokenFromContext(HttpContext context)
    {
        bool tokenIsInHeaders = context.Request.Headers.TryGetValue("Authorization", out StringValues token);

        if (string.IsNullOrEmpty(token) && !tokenIsInHeaders)
        {
            throw new TokenNotFoundInHeadersException();
        }

        return token;
    }
}

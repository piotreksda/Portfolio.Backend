using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Portfolio.Domain.Core.Infrastructure.Services.Interfaces;
using System.Security.Claims;

namespace Portfolio.Domain.Core.Infrastructure.Attributes;

public class PermissionAuth : Attribute, IAsyncActionFilter
{
    public string[] Permissions { get; set; }
    
    public PermissionAuth(params string[] permissions)
    {
        Permissions = permissions;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        IJwtTokenService jwtTokenService = context.HttpContext.RequestServices.GetRequiredService<IJwtTokenService>();
        
        string token = jwtTokenService.GetTokenFromContext(context);

        IEnumerable<Claim> claims = await jwtTokenService.CheckIfTokenIsValidAndReturnCalms(token);

        if (!claims.Any(claim => Permissions.Contains(claim.Value)))
        {
            throw new ForbiddenException();
        }
       
        await next();
    }
}

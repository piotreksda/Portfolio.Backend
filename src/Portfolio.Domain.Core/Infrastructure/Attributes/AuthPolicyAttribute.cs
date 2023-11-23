using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core.Infrastructure.Attributes;

public class AuthPolicyAttribute : Attribute, IAsyncActionFilter
{
    public string[] Permissions { get; set; }
    
    public AuthPolicyAttribute(params string[] permissions)
    {
        Permissions = permissions;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        IIdentityContext identityContext = context.HttpContext.RequestServices.GetService<IIdentityContext>();

        if (!Permissions.All(x => identityContext.Permissions.Contains(x)))
        {
            throw new ForbiddenException();
        }
        // IJwtTokenService jwtTokenService = context.HttpContext.RequestServices.GetRequiredService<IJwtTokenService>();
        //
        // string token = jwtTokenService.GetTokenFromContext(context.HttpContext);
        //
        // IEnumerable<Claim> claims = await jwtTokenService.CheckIfTokenIsValidAndReturnCalms(token);
        //
        //
        // if (!claims.Any(claim => Permissions.Contains(claim.Value)))
        // {
        //     throw new ForbiddenException();
        // }
       
        await next();
    }
}

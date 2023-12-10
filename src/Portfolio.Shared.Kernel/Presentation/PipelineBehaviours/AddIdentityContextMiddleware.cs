using Microsoft.AspNetCore.Http;
using Portfolio.Shared.Kernel.Infrastructure.Services;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Infrastructure.Attributes;

namespace Portfolio.Shared.Kernel.Presentation.PipelineBehaviours;

public class AddIdentityContextMiddleware : IMiddleware
{
    private readonly IIdentityContext _identityContext;
    private readonly IJwtTokenService _jwtTokenService;
    public AddIdentityContextMiddleware(IIdentityContext identityContext, IJwtTokenService jwtTokenService)
    {
        _identityContext = identityContext;
        _jwtTokenService = jwtTokenService;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Endpoint? endpoint = context.GetEndpoint();
        if (endpoint is not null)
        {
            AuthPolicyAttribute? authPolicyAttr = endpoint.Metadata.GetMetadata<AuthPolicyAttribute>();
            if (authPolicyAttr != null)
            {
                PrepareUserInIdentityContext(context);
            }
        }
        
        await next(context);
    }

    private void PrepareUserInIdentityContext(HttpContext context)
    {
        string token = _jwtTokenService.GetTokenFromContext(context);

        _identityContext.Configure(token);
    }
}
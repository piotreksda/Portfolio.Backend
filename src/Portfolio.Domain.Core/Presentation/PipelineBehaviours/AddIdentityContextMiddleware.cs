using Microsoft.AspNetCore.Http;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Infrastructure.Attributes;
using Portfolio.Domain.Core.Infrastructure.Services;

namespace Portfolio.Domain.Core.Presentation.PipelineBehaviours;

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
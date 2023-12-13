using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;

namespace Portfolio.Authorization.Service.Application.ValidateActionToken;

public class ValidateActionTokenQueryHandler : IRequestHandler<ValidateActionTokenQuery, bool>
{
    private readonly IActionTokenService _actionTokenService;

    public ValidateActionTokenQueryHandler(IActionTokenService actionTokenService)
    {
        _actionTokenService = actionTokenService;
    }

    public async Task<bool> Handle(ValidateActionTokenQuery request, CancellationToken cancellationToken)
    {
        await _actionTokenService.ValidateActionToken(request.ActionTokenType, request.Token, false);
        return true;
    }
}
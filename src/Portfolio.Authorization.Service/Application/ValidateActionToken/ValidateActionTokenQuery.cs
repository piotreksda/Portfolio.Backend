using MediatR;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Application.ValidateActionToken;

public class ValidateActionTokenQuery : IRequest<bool>
{
    public ValidateActionTokenQuery(string token, ActionTokenTypes actionTokenType)
    {
        Token = token;
        ActionTokenType = actionTokenType;
    }
    public string Token { get; init; }
    public ActionTokenTypes ActionTokenType { get; init; }
}
using MediatR;

namespace Portfolio.Authorization.Service.Application.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<bool>
{
    public ConfirmEmailCommand(string token)
    {
        Token = token;
    }

    public string Token { get; init; }
}
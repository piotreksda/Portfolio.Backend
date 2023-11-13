using MediatR;
using Portfolio.Authorization.Service.Application.Commands;

namespace Portfolio.Authorization.Service.Application.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    public Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
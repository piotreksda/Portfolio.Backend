using MediatR;
using Portfolio.Authorization.Service.Application.Commands;

namespace Portfolio.Authorization.Service.Application.Handlers;

public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommand, bool>
{
    public Task<bool> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
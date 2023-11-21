using MediatR;

namespace Portfolio.Authorization.Service.Application.LogoutUser;

public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommand, bool>
{
    public Task<bool> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
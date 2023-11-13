using MediatR;
using Portfolio.Authorization.Service.Application.Commands;

namespace Portfolio.Authorization.Service.Application.Handlers;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, bool>
{
    public Task<bool> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
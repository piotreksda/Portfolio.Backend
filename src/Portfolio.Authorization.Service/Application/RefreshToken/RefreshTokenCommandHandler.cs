using MediatR;

namespace Portfolio.Authorization.Service.Application.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, bool>
{
    public async Task<bool> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return true;
    }
}
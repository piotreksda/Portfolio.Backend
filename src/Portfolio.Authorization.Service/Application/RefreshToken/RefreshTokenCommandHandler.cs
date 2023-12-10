using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.NotFoundExceptions;

namespace Portfolio.Authorization.Service.Application.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public RefreshTokenCommandHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new UserNotFoundException();
        }

        bool isRefreshTokenValid = user.CheckIfRefreshTokenIsValid(request.RefreshToken);

        if (!isRefreshTokenValid)
        {
            throw new Exception();
        }

        var handler = new JwtSecurityTokenHandler();
        var token = await _jwtTokenService.CreateTokenForUser(user);

        user.GenerateNewSecurityStamp();
        await _userRepository.Update(user);
        
        return handler.WriteToken(token);
    }
}
using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.NotFoundExceptions;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.UnauthorizedExceptions;

namespace Portfolio.Authorization.Service.Application.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginUserCommandHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await ValidateUserCredentials(request.LoginModel);
        var token = await GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken(user, request.LoginModel.RememberMe);
        
        await UpdateUserWithRefreshToken(user, refreshToken);
        
        return BuildLoginDto(user, token, refreshToken);
    }

    private async Task<ApplicationUser> ValidateUserCredentials(LoginInputModel loginModel)
    {
        var user = await _userRepository.GetUserByUserNameOrEmail(loginModel.Login);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        bool passwordIsValid = Password.VerifyPassword(loginModel.Password, user.PasswordHash);
        if (!passwordIsValid)
        {
            throw new WrongPasswordException();
        }

        return user;
    }

    private async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
    {
        return await _jwtTokenService.CreateTokenForUser(user);
    }

    private Shared.Kernel.Domain.Auth.Entities.RefreshToken GenerateRefreshToken(ApplicationUser user, bool rememberMe)
    {
        DateTime refreshTokenValidTo = rememberMe ? DateTime.UtcNow.AddMonths(2) : DateTime.UtcNow.AddDays(2);
        RefreshTokenValue refreshTokenValue = RefreshTokenValue.GenerateRefreshTokenValue();
        
        return new Shared.Kernel.Domain.Auth.Entities.RefreshToken(user, refreshTokenValue, refreshTokenValidTo);
    }

    private async Task UpdateUserWithRefreshToken(ApplicationUser user, Shared.Kernel.Domain.Auth.Entities.RefreshToken refreshToken)
    {
        user.AddRefreshToken(refreshToken);
        await _userRepository.Update(user);
    }

    private LoginDto BuildLoginDto(ApplicationUser user, JwtSecurityToken token, Shared.Kernel.Domain.Auth.Entities.RefreshToken refreshToken)
    {
        var handler = new JwtSecurityTokenHandler();
        return new LoginDto
        {
            UserId = user.Id,
            Token = handler.WriteToken(token),
            RefreshToken = RefreshTokenValue.ConvertToString(refreshToken.Token.Value),
        };
    }
}

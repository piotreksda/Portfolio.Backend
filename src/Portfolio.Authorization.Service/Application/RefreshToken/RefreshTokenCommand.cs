// using FluentValidation;
using MediatR;

namespace Portfolio.Authorization.Service.Application.RefreshToken;

public class RefreshTokenCommand : IRequest<string>
{
    public RefreshTokenCommand(int userId, string refreshToken)
    {
        UserId = userId;
        RefreshToken = refreshToken;
    }

    public int UserId { get; init; }
    public string RefreshToken { get; init; }
    // public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    // {
    //     
    // }
}
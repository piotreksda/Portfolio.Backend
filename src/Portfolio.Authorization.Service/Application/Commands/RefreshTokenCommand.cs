using FluentValidation;
using MediatR;

namespace Portfolio.Authorization.Service.Application.Commands;

public class RefreshTokenCommand : IRequest<bool>
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        
    }
}
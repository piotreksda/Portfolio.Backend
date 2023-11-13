using FluentValidation;
using MediatR;

namespace Portfolio.Authorization.Service.Application.Commands;

public class RegisterUserCommand : IRequest<bool>
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        
    }
}
using FluentValidation;
using MediatR;

namespace Portfolio.Authorization.Service.Application.Commands;

public class LogOutUserCommand : IRequest<bool>
{
    public class LogOutUserCommandValidator : AbstractValidator<LogOutUserCommand>
    {
        
    }
}
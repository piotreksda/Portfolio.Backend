using FluentValidation;
using MediatR;
using Portfolio.Authorization.Service.Domain.Dtos;
using Portfolio.Authorization.Service.Domain.Entities.Models;

namespace Portfolio.Authorization.Service.Application.Commands;

public class LoginUserCommand : IRequest<LoginDto>
{
    public LoginInputModel LoginModel;
    public int LanguageId;
    public LoginUserCommand(LoginInputModel loginModel, int languageId)
    {
        LoginModel = loginModel;
        LanguageId = languageId;
    }

    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        
    }
}

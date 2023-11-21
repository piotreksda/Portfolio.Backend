// using FluentValidation;
using MediatR;

namespace Portfolio.Authorization.Service.Application.LoginUser;

public class LoginUserCommand : IRequest<LoginDto>
{
    public LoginInputModel LoginModel;
    public int LanguageId;
    public LoginUserCommand(LoginInputModel loginModel, int languageId)
    {
        LoginModel = loginModel;
        LanguageId = languageId;
    }

    // public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    // {
    //     
    // }
}

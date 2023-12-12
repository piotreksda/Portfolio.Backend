// using FluentValidation;
using MediatR;

namespace Portfolio.Authorization.Service.Application.RegisterUser;

public class RegisterUserCommand : IRequest<bool>
{
    public RegisterInputModel RegisterModel { get; init; }
    public int LangId { get; init; }

    public RegisterUserCommand(RegisterInputModel registerModel, int langId)
    {
        RegisterModel = registerModel;
        LangId = langId;
    }
    //
    // public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    // {
    //     public RegisterUserCommandValidator()
    //     {
    //
    //         // Validate UserName
    //         RuleFor(x => x.RegisterModel.UserName)
    //             .NotNull()
    //             .Length(3, 50);
    //         RuleFor(x => x.RegisterModel.Email)
    //             .SetValidator(new EmailValidator());
    //         RuleFor(x => x.RegisterModel.Password)
    //             .SetValidator(new PasswordValidator());
    //     }
    //     
    // }
}
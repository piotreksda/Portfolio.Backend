// using FluentValidation;
using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;

namespace Portfolio.Authorization.Service.Application.RegisterUser;

public class RegisterUserCommand : IRequest<bool>, UseTransactionScopeSaveLogic
{
    public RegisterInputModel RegisterModel { get; init; }
    public int LangId { get; init; }
    public string Url { get; init; }

    public RegisterUserCommand(RegisterInputModel registerModel, int langId, string url)
    {
        RegisterModel = registerModel;
        LangId = langId;
        Url = url;
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
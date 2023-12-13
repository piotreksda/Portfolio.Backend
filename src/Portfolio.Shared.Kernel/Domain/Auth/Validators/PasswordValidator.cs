// using FluentValidation;
// using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
//
// namespace Portfolio.Shared.Kernel.Domain.Auth.Validators;
//
// public class PasswordValidator : AbstractValidator<string>
// {
//     public PasswordValidator()
//     {
//         RuleFor(password => password)
//             .NotEmpty()
//             .Length(Password.MinLen, Password.MaxLen)
//             .Matches(Password.ValidationRegex);
//     }
// }
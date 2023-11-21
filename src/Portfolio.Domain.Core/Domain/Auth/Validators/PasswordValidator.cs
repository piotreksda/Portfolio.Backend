// using FluentValidation;
// using Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects;
//
// namespace Portfolio.Domain.Core.Domain.Auth.Validators;
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
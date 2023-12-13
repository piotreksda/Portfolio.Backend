// using FluentValidation;
// using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
//
// namespace Portfolio.Shared.Kernel.Domain.Auth.Validators;
//
// public class EmailValidator : AbstractValidator<string>
// {
//     public EmailValidator()
//     {
//         RuleFor(email => email)
//             .NotEmpty()
//             .Length(Email.MinLen, Email.MaxLen)
//             .Matches(Email.ValidationRegex);
//     }
// }
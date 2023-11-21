// using FluentValidation;
// using Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects;
//
// namespace Portfolio.Domain.Core.Domain.Auth.Validators;
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
using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Domain.Constants;
using RazorTemplateEngine.Templates.Shared;
using RazorTemplateEngine.Views.RegistrationConfirmation;

namespace Portfolio.Authorization.Service.Application.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        Email email = new Email(request.RegisterModel.Email);
        
        Password password = new Password(request.RegisterModel.Password);

        ApplicationUser user = new ApplicationUser(request.RegisterModel.UserName, email);
        
        user.SetPassword(Password.HashPassword(password));

        await _emailService.SendEmailAsync(request.RegisterModel.Email, MailTemplates.RegistrationConfirmation, new RegistrationConfirmationModel()
        {
            Token = "randomtokenXD",
            Url = "test.xd",
            UserName = request.RegisterModel.UserName,
            Subject = "Email confirmation"
            
        });
        
        await _userRepository.AddAsync(user);
        
        return true;
    }
}
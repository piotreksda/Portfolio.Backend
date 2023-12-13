using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.BadRequestExceptions;
using RazorTemplateEngine.Views.RegistrationConfirmation;

namespace Portfolio.Authorization.Service.Application.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IActionTokenService _actionTokenService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IEmailService emailService, IActionTokenService actionTokenService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _actionTokenService = actionTokenService;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        Email email = new Email(request.RegisterModel.Email);

        await CheckIfUserNameOrEmailIsTaken(email, request.RegisterModel.UserName);
        
        Password password = new Password(request.RegisterModel.Password);

        ApplicationUser user = new ApplicationUser(request.RegisterModel.UserName, email);
        
        user.SetPassword(Password.HashPassword(password));

        await _userRepository.AddAsync(user);

        await _userRepository.SaveChangesAsync();
        
        await SendMail(request, user.Id);
        
        return true;
    }

    private async Task CheckIfUserNameOrEmailIsTaken(Email email, string userName)
    {
        bool emailIsUsed = await _userRepository.CheckIfEmailIsUsed(email);
        bool usernameIsUsed = await _userRepository.CheckIfUserNameIsUsed(userName);

        if (emailIsUsed)
        {
            throw new EmailAlreadyTakenException();
        }

        if (usernameIsUsed)
        {
            throw new UserNameAlreadyTakenException();
        }
    }
    
    private async Task SendMail(RegisterUserCommand request, int userId)
    {
        string token = await _actionTokenService.GenerateActionToken(ActionTokenTypes.ConfirmEmail, userId);
        
        await _emailService.SendEmailAsync(request.RegisterModel.Email, MailTemplates.RegistrationConfirmation, new RegistrationConfirmationModel()
        {
            Token = token,
            Url = request.Url,
            UserName = request.RegisterModel.UserName,
            Subject = "Email confirmation",
            LangId = request.LangId
            
        });
    }
}
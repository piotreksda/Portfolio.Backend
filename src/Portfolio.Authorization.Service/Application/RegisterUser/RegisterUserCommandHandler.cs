using MediatR;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain.Auth.Entities;
using Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects;

namespace Portfolio.Authorization.Service.Application.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        Email email = new Email(request.RegisterModel.Email);
        Password password = new Password(request.RegisterModel.Password);

        ApplicationUser user = new ApplicationUser(request.RegisterModel.UserName, email);
        
        user.SetPassword(Password.HashPassword(password));

        await _userRepository.AddAsync(user);
        
        return true;
    }
}
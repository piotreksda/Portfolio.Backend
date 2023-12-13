using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.NotFoundExceptions;

namespace Portfolio.Authorization.Service.Application.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
{
    private readonly IActionTokenService _actionTokenService;
    private readonly IUserRepository _userRepository;
    public ConfirmEmailCommandHandler(IActionTokenService actionTokenService, IUserRepository userRepository)
    {
        _actionTokenService = actionTokenService;
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        int userId = await _actionTokenService.ValidateActionToken(ActionTokenTypes.ConfirmEmail, request.Token, true);

        ApplicationUser? user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException();
        }

        user.ConfirmEmail();

        await _userRepository.Update(user);

        return true;
    }
}
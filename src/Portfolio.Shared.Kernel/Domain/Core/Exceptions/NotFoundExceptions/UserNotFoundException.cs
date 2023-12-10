using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.NotFoundExceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base(ExceptionsTranslationsKeys.UserNotFoundTitle, ExceptionsTranslationsKeys.UserNotFoundMessage)
    {
    }
}
using Portfolio.Domain.Core.Domain.Constants;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.NotFoundExceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base(ExceptionsTranslationsKeys.UserNotFoundTitle, ExceptionsTranslationsKeys.UserNotFoundMessage)
    {
    }
}
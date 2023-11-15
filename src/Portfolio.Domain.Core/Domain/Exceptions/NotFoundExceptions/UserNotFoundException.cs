using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core.Domain.Exceptions.NotFoundExceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base(ExceptionsTranslationsKeys.UserNotFoundTitle, ExceptionsTranslationsKeys.UserNotFoundMessage)
    {
    }
}
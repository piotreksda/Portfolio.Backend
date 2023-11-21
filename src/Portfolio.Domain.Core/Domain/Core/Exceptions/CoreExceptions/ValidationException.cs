using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class ValidationException : PortfolioApplicationException
{
    public ValidationException(string? message = null) : base(ExceptionsTranslationsKeys.ValidationExceptionTitle, message ?? ExceptionsTranslationsKeys.ValidationExceptionMessage)
    {
    }
}
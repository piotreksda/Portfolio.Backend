using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

public class ValidationException : PortfolioApplicationException
{
    public ValidationException(string? message = null) : base(ExceptionsTranslationsKeys.ValidationExceptionTitle, message ?? ExceptionsTranslationsKeys.ValidationExceptionMessage)
    {
    }
}
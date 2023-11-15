using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class InvalidStateException : PortfolioApplicationException
{
    protected InvalidStateException(string title, string message) : base(title, message)
    {
    }

    public InvalidStateException() : base(ExceptionsTranslationsKeys.InvalidStateTitle, ExceptionsTranslationsKeys.InvalidStateMessage)
    {
    }
}
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

public class InvalidStateException : PortfolioApplicationException
{
    protected InvalidStateException(string title, string message) : base(title, message)
    {
    }

    public InvalidStateException() : base(ExceptionsTranslationsKeys.InvalidStateTitle, ExceptionsTranslationsKeys.InvalidStateMessage)
    {
    }
}
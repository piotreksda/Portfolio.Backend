using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core.Domain.Exceptions.CoreExceptions;

public class InvalidStateException : PortfolioApplicationException
{
    protected InvalidStateException(string title, string message) : base(title, message)
    {
    }

    public InvalidStateException() : base(ExceptionsTranslationsKeys.InvalidStateTitle, ExceptionsTranslationsKeys.InvalidStateMessage)
    {
    }
}
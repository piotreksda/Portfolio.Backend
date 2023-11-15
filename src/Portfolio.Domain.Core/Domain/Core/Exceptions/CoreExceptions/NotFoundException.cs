using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class NotFoundException : PortfolioApplicationException
{
    protected NotFoundException(string title, string message) : base(title, message)
    {
        
    }

    public NotFoundException() : base(ExceptionsTranslationsKeys.NotFoundTitle,
        ExceptionsTranslationsKeys.NotFoundMessage)
    {
        
    }
}
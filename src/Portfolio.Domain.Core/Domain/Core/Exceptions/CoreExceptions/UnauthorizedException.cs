using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class UnauthorizedException : PortfolioApplicationException
{
    protected UnauthorizedException(string title, string message) : base(title, message)
    {
        
    }

    public UnauthorizedException() : base(ExceptionsTranslationsKeys.UnauthorizedTitle,
        ExceptionsTranslationsKeys.UnauthorizedMessage)
    {
        
    }
}
using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core.Domain.Exceptions.CoreExceptions;

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
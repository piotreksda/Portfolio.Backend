using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

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
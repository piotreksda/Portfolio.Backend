using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

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
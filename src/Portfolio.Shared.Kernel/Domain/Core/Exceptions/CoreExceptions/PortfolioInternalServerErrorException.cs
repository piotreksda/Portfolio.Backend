using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

public class PortfolioInternalServerErrorException : PortfolioApplicationException
{
    protected PortfolioInternalServerErrorException(string title, string message) : base(title, message)
    {
        
    }
    public PortfolioInternalServerErrorException() : base(ExceptionsTranslationsKeys.DefaultErrorTitle, ExceptionsTranslationsKeys.DefaultErrorMessage)
    {
    }
}
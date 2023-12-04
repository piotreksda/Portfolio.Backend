using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class PortfolioInternalServerErrorException : PortfolioApplicationException
{
    protected PortfolioInternalServerErrorException(string title, string message) : base(title, message)
    {
        
    }
    public PortfolioInternalServerErrorException() : base(ExceptionsTranslationsKeys.DefaultErrorTitle, ExceptionsTranslationsKeys.DefaultErrorMessage)
    {
    }
}
using Portfolio.Domain.Core.Domain.Constants;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.InternalServerErrorExceptions;

public class UnableToSendEmailException : PortfolioInternalServerErrorException
{
    public UnableToSendEmailException() : base(ExceptionsTranslationsKeys.UnableToSendEmailTitle, ExceptionsTranslationsKeys.UnableToSendEmailMessage)
    {
        
    }
}
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.InternalServerErrorExceptions;

public class UnableToSendEmailException : PortfolioInternalServerErrorException
{
    public UnableToSendEmailException() : base(ExceptionsTranslationsKeys.UnableToSendEmailTitle, ExceptionsTranslationsKeys.UnableToSendEmailMessage)
    {
        
    }
}
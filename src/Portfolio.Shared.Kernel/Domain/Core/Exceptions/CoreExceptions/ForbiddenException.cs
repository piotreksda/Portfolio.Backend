using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

public class ForbiddenException : PortfolioApplicationException
{
    public ForbiddenException() : base(ExceptionsTranslationsKeys.ForbiddenTitle, ExceptionsTranslationsKeys.ForbiddenMessage)
    {
    }
}

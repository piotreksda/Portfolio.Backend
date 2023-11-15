using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class ForbiddenException : PortfolioApplicationException
{
    public ForbiddenException() : base(ExceptionsTranslationsKeys.ForbiddenTitle, ExceptionsTranslationsKeys.ForbiddenMessage)
    {
    }
}

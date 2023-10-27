using Portfolio.Domain.Core.Domain.Exceptions;
using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core;

public class ForbiddenException : PortfolioApplicationException
{
    public ForbiddenException() : base(ExceptionsTranslationsKeys.ForbiddenTitle, ExceptionsTranslationsKeys.ForbiddenMessage)
    {
    }
}

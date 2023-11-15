using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core.Domain.Exceptions;

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
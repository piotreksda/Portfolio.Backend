using Portfolio.Domain.Core.Domain.Exceptions.CoreExceptions;
using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core.Domain.Exceptions.UnauthorizedExceptions;

public class TokenNotFoundInHeadersException : UnauthorizedException
{
    public TokenNotFoundInHeadersException() : base(ExceptionsTranslationsKeys.TokenNotFoundInHeadersTitle, ExceptionsTranslationsKeys.TokenNotFoundInHeadersMessage)
    {
        
    }
}
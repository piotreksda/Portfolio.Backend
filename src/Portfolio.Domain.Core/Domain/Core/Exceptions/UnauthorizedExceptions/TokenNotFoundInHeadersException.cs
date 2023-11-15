using Portfolio.Domain.Core.Domain.Constants;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.UnauthorizedExceptions;

public class TokenNotFoundInHeadersException : UnauthorizedException
{
    public TokenNotFoundInHeadersException() : base(ExceptionsTranslationsKeys.TokenNotFoundInHeadersTitle, ExceptionsTranslationsKeys.TokenNotFoundInHeadersMessage)
    {
        
    }
}
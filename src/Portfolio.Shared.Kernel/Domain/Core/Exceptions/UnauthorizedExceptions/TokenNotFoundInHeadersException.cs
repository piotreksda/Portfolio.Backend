using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.UnauthorizedExceptions;

public class TokenNotFoundInHeadersException : UnauthorizedException
{
    public TokenNotFoundInHeadersException() : base(ExceptionsTranslationsKeys.TokenNotFoundInHeadersTitle, ExceptionsTranslationsKeys.TokenNotFoundInHeadersMessage)
    {
        
    }
}
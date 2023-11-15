using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.UnauthorizedExceptions;

public class TokenExpiredException : UnauthorizedException
{
    public TokenExpiredException() : base(title: "", message: "")
    {
    }
}

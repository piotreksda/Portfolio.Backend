using Portfolio.Domain.Core.Domain.Exceptions;
using Portfolio.Domain.Core.Domain.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core;

public class TokenExpiredException : UnauthorizedException
{
    public TokenExpiredException() : base(title: "", message: "")
    {
    }
}

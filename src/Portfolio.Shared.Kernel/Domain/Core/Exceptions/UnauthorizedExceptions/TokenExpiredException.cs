using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.UnauthorizedExceptions;

public class TokenExpiredException : UnauthorizedException
{
    public TokenExpiredException() : base(title: "", message: "")
    {
    }
}

using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.UnauthorizedExceptions;

public class WrongPasswordException : UnauthorizedException
{
    public WrongPasswordException() : base(title: "", message: "")
    {
    }
}
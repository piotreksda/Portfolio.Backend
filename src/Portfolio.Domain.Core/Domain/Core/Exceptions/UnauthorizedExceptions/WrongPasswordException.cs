using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.UnauthorizedExceptions;

public class WrongPasswordException : UnauthorizedException
{
    public WrongPasswordException() : base(title: "", message: "")
    {
    }
}
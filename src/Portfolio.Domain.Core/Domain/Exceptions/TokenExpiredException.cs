using Portfolio.Domain.Core.Domain.Exceptions;

namespace Portfolio.Domain.Core;

public class TokenExpiredException : PortfolioApplicationException
{
    public TokenExpiredException() : base(title: "", message: "")
    {
    }
}

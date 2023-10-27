using Portfolio.Domain.Core.Domain.Exceptions;

namespace Portfolio.Domain.Core;

public class TokenValidationException : PortfolioApplicationException
{
    public TokenValidationException() : base(title: "", message: "")
    {
        
    }
}

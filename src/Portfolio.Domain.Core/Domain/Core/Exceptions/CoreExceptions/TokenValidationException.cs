namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class TokenValidationException : PortfolioApplicationException
{
    public TokenValidationException() : base(title: "", message: "")
    {
        
    }
}

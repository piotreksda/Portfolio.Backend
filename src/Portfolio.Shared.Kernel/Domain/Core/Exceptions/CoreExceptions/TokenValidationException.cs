namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

public class TokenValidationException : PortfolioApplicationException
{
    public TokenValidationException() : base(title: "", message: "")
    {
        
    }
}

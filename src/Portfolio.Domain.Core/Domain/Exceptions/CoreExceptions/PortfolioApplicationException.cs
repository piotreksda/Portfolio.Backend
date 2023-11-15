namespace Portfolio.Domain.Core.Domain.Exceptions;

public abstract class PortfolioApplicationException : Exception
{
    public string Title { get; }
    protected PortfolioApplicationException(string title, string message)
        : base(message) 
    {
        Title = title;
    }
}

using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;

public class BadRequestException : PortfolioApplicationException
    {
        public BadRequestException(string message = "")
            : base(ExceptionsTranslationsKeys.BadRequestTitle, (string.IsNullOrEmpty(message) ? ExceptionsTranslationsKeys.BadRequestMessage : message))
        {
        }
    }

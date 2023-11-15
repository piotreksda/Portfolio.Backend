using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Domain.Core.Domain.Exceptions;

public class BadRequestException : PortfolioApplicationException
    {
        public BadRequestException(string message = "")
            : base(ExceptionsTranslationsKeys.BadRequestTitle, (string.IsNullOrEmpty(message) ? ExceptionsTranslationsKeys.BadRequestMessage : message))
        {
        }
    }

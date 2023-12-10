using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

public class BadRequestException : PortfolioApplicationException
    {
        public BadRequestException(string message = "")
            : base(ExceptionsTranslationsKeys.BadRequestTitle, (string.IsNullOrEmpty(message) ? ExceptionsTranslationsKeys.BadRequestMessage : message))
        {
        }
    }

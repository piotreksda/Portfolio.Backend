using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;

namespace Portfolio.Shared.Kernel.Domain.Core.Exceptions.BadRequestExceptions;

public class ActionTokenAlreadyUsedException : BadRequestException
{
    public ActionTokenAlreadyUsedException() : base(ExceptionsTranslationsKeys.ActionTokenAlreadyUsedMessage)
    {
        
    }
}
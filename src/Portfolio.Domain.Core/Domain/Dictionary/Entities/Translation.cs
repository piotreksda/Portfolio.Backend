using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Dictionary.Entities;

public class Translation : BaseAuditableEntity<Guid>
{
    public string TranslationKey { get; private set; }
    public string TranslationContent { get; private set; }

    private Translation()
    {
        
    }
}
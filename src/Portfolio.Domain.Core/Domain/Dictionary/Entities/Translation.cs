using Portfolio.Domain.Core.Domain.Entites;
using Portfolio.Domain.Core.Domain.Primitives;

namespace Portfolio.Domain.Core.Domain.Dictionary.Entities;

public class Translation : BaseAuditableEntity<Guid>
{
    public string TranslationKey { get; private set; }
    public string TranslationContent { get; private set; }

    private Translation()
    {
        
    }
}
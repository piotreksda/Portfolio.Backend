using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Dictionary.Entities;

public class Translation : BaseAuditableEntity<int>
{
    public string TranslationKey { get; private set; }
    public string TranslationContent { get; private set; }
    public int LangId { get; private set; }
    public virtual Language Language { get; private set; }
    public int TranslationTypeId { get; private set; }
    public virtual TranslationType TranslationType { get; private set; }

    private Translation()
    {
        
    }

    public Translation(string translationKey, string translationContent, int langId)
    {
        TranslationKey = translationKey;
        TranslationContent = translationContent;
        LangId = langId;
    }
}
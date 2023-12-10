using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Dictionary.Entities;

public class TranslationType : BaseAuditableEntity<int>
{
    public TranslationType()
    {
        Translations = new HashSet<Translation>();
    }
    public string Name { get; private set; }
    public virtual ICollection<Translation> Translations { get; private set; }
}
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Dictionary.Entities;

public class Language : BaseEntity<int>
{
    public string Name { get; private set; }
    public string IsoCode { get; private set; }
    public virtual ICollection<Translation> Translations { get; private set; }

    private Language()
    {
        Translations = new HashSet<Translation>();
    }

    public Language(string name, string isoCode)
    {
        Name = name;
        IsoCode = isoCode;
        Translations = new HashSet<Translation>();
    }
}
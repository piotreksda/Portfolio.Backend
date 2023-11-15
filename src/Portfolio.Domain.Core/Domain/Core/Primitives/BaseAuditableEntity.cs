namespace Portfolio.Domain.Core.Domain.Core.Primitives;

public abstract class BaseAuditableEntity<T> : BaseEntity<T> where T : struct 
{
    public DateTime CreatedAt { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime ModifiedAt { get; private set; }
    public int ModifiedBy { get; private set; }
}
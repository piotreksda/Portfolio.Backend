using Portfolio.Shared.Kernel.Domain.Auth.Entities;

namespace Portfolio.Shared.Kernel.Domain.Core.Primitives;

public interface IAuditableEntity
{
    public DateTime CreatedAt { get; }
    public int CreatedBy { get; }
    public DateTime? ModifiedAt { get; } 
    public int? ModifiedBy { get; }

    void SetCreatedValues(int createdBy, DateTime createdAt);
    void UpdateModifiedValues(int? modifiedBy, DateTime? modifiedAt);
}

public abstract class BaseAuditableEntity<T> : BaseEntity<T>, IAuditableEntity where T : struct 
{
    public DateTime CreatedAt { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public int? ModifiedBy { get; private set; }

    public void SetCreatedValues(int createdBy, DateTime createdAt)
    {
        CreatedBy = createdBy;
        CreatedAt = createdAt;
    }
    
    public void UpdateModifiedValues(int? modifiedBy, DateTime? modifiedAt)
    {
        ModifiedBy = modifiedBy;
        ModifiedAt = modifiedAt;
    }
}
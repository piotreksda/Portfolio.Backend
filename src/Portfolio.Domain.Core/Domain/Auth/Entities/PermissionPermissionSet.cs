using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class PermissionPermissionSet : BaseAuditableEntity<int>
{
    public int PermissionId { get; private set; }
    public virtual Permission Permission { get; private set; }
    public int PermissionSetId { get; private set; }
    public virtual PermissionSet PermissionSet { get; private set; }
}
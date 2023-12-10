using Portfolio.Shared.Kernel.Domain.Entites;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class PermissionPermissionSet : BaseAuditableEntity<int>
{
    public int PermissionId { get; private set; }
    public virtual Permission Permission { get; private set; }
    public int PermissionSetId { get; private set; }
    public virtual PermissionSet PermissionSet { get; private set; }
}
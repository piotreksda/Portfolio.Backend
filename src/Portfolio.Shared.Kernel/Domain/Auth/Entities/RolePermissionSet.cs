using Portfolio.Shared.Kernel.Domain.Entites;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class RolePermissionSet : BaseAuditableEntity<int>
{
    public int PermissionSetId { get; private set; }
    public PermissionSet PermissionSet { get; private set; }
    public int RoleId { get; private set; }
    public virtual ApplicationRole Role { get; private set; }
}
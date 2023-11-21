using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class RolePermissionSet : BaseAuditableEntity<int>
{
    public int PermissionSetId { get; private set; }
    public PermissionSet PermissionSet { get; private set; }
    public int RoleId { get; private set; }
    public virtual ApplicationRole Role { get; private set; }
}
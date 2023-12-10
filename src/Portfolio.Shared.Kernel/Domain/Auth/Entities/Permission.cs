using Microsoft.AspNetCore.Identity;
using Portfolio.Shared.Kernel.Domain.Entites;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class Permission : BaseAuditableEntity<int>
{
    public string Name { get; private set; }
    public virtual ICollection<PermissionPermissionSet> PermissionPermissionSet { get; private set; }
}

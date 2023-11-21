using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class PermissionSet : BaseAuditableEntity<int>
{
    public string Name { get; private set; }
    public virtual ICollection<PermissionPermissionSet> PermissionPermissionSet { get; private set; }
    
}
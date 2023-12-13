using Portfolio.Shared.Kernel.Domain.Entites;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class ApplicationRole : BaseAuditableEntity<int>
{
    private ApplicationRole()
    {
    }

    public ApplicationRole(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }
    public virtual ICollection<UserRole> UsersRoles { get; private set; }
    public virtual ICollection<RolePermissionSet> RolesPermissionSets { get; private set; }
}
using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

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
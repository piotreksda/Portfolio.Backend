using Microsoft.AspNetCore.Identity;
using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class Permission : BaseAuditableEntity<int>
{

    // public virtual ICollection<IdentityRoleClaim<int>> Claims { get; private set; }
    // public virtual ICollection<AspNetRolesTranslation> AspNetRolesTranslations { get; private set; }
    // public virtual ICollection<AspNetRolesClaimsTranslation> AspNetRolesCLaimsTranslations { get; private set; }
    // public virtual ICollection<PermissionSetRole> PermissionSetsRoles { get; private set; }

    // public ApplicationRole(string name) : base(name)
    // {
    //     // AspNetRolesTranslations = new List<AspNetRolesTranslation>();
    //     // PermissionSetsRoles = new List<PermissionSetRole>();
    // }
}

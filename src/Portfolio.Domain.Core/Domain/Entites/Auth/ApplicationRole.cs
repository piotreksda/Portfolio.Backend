using Microsoft.AspNetCore.Identity;

namespace Portfolio.Domain.Core.Domain.Entities.Auth;

public class ApplicationRole: IdentityRole<int>
{
    public new string Name
    {
        get => base.Name;
        private set => base.Name = value;
    }

    public new string NormalizedName
    {
        get => base.NormalizedName;
        private set => base.NormalizedName = value;
    }

    public virtual ICollection<IdentityRoleClaim<int>> Claims { get; private set; }
    // public virtual ICollection<AspNetRolesTranslation> AspNetRolesTranslations { get; private set; }
    // public virtual ICollection<AspNetRolesClaimsTranslation> AspNetRolesCLaimsTranslations { get; private set; }
    // public virtual ICollection<PermissionSetRole> PermissionSetsRoles { get; private set; }

    public ApplicationRole(string name) : base(name)
    {
        // AspNetRolesTranslations = new List<AspNetRolesTranslation>();
        // PermissionSetsRoles = new List<PermissionSetRole>();
    }
}

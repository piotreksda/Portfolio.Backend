using Microsoft.AspNetCore.Identity;
using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class ApplicationUser : BaseAuditableEntity<int>
{
    public string UserName { get; private set; }
    public string NormalizedUserName { get; private set; }
    
    public string Email { get; private set; }
    public string NormalizedEmail { get; private set; }
    public bool EmailConfirmed { get; private set; }
    
    public byte[] PasswordHash { get; private set; }
    public Guid SecurityStamp { get; private set; }
    
    public string PhoneNumber { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    
    public bool TwoFactorEnabled { get; private set; }
    
    public DateTime LockoutEnd { get; private set;  }

    public int AccessFailedCount { get; private set; }


    // public virtual ICollection<IdentityUserClaim<int>> Claims { get; private set; }
    // public virtual ICollection<IdentityUserLogin<int>> Logins { get; private set; }
    // public virtual ICollection<IdentityUserToken<int>> Tokens { get; private set; }
    // public virtual ICollection<IdentityUserRole<int>> Roles { get; private set; }
    // public virtual Person Person { get; set; }
    // public virtual ICollection<UsersActivityLog> UsersActivityLogs { get; private set; }
    // public virtual ICollection<UsersObject> UsersObjects { get; private set; }
    // public virtual ICollection<UsersParentOrganization> UsersParentOrganizations { get; private set; }
    // public virtual ICollection<UserRepository> UsersRepositories { get; private set; }
    // public virtual ICollection<Setting> Settings { get; private set; }
}

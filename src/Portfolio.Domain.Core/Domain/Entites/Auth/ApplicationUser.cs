using Microsoft.AspNetCore.Identity;

namespace Portfolio.Domain.Core.Domain.Entities.Auth;

public class ApplicationUser : IdentityUser<int> 
{
    public virtual ICollection<IdentityUserClaim<int>> Claims { get; private set; }
    public virtual ICollection<IdentityUserLogin<int>> Logins { get; private set; }
    public virtual ICollection<IdentityUserToken<int>> Tokens { get; private set; }
    public virtual ICollection<IdentityUserRole<int>> Roles { get; private set; }
    // public virtual Person Person { get; set; }
    // public virtual ICollection<UsersActivityLog> UsersActivityLogs { get; private set; }
    // public virtual ICollection<UsersObject> UsersObjects { get; private set; }
    // public virtual ICollection<UsersParentOrganization> UsersParentOrganizations { get; private set; }
    // public virtual ICollection<UserRepository> UsersRepositories { get; private set; }
    // public virtual ICollection<Setting> Settings { get; private set; }
}

using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class UserRole : BaseAuditableEntity<int>
{
    private UserRole()
    {
        
    }

    public UserRole(ApplicationUser user, ApplicationRole role)
    {
        User = user;
        Role = role;
    }
    
    public virtual ApplicationUser User { get; private set; }
    public int UserId { get; private set; }
    public virtual ApplicationRole Role { get; private set; }
    public int RoleId { get; private set; }
}
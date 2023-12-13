using System.Text;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Domain.Core.Entities;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class ApplicationUser : BaseAuditableEntity<int>
{
    private ApplicationUser()
    {
        
    }

    public ApplicationUser(string userName, Email email)
    {
        UserName = userName;
        NormalizedUserName = userName.ToUpper();
        Email = email;
        NormalizedEmail = email.GetNormalizedEmail();
    }
    public string UserName { get; private set; }
    public string NormalizedUserName { get; private set; }
    
    public Email Email { get; private set; }
    public Email NormalizedEmail { get; private set; }
    public bool EmailConfirmed { get; private set; }
    
    public byte[] PasswordHash { get; private set; }
    public Guid SecurityStamp { get; private set; }
    
    public PhoneNumber? PhoneNumber { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    
    public bool TwoFactorEnabled { get; private set; }
    
    public DateTime? LockoutEnd { get; private set;  }

    public int AccessFailedCount { get; private set; }

    public virtual ICollection<UserRole> UsersRoles { get; private set; } = new HashSet<UserRole>();
    public virtual ICollection<RefreshToken> RefreshTokens { get; private set; } = new HashSet<RefreshToken>();
    public virtual ICollection<LoginHistory> LoginHistories { get; private set; } = new HashSet<LoginHistory>();
    public virtual ICollection<ActionToken> ActionTokens { get; private set; } = new HashSet<ActionToken>();

    public void SetPassword(byte[] passwordHash)
    {
        PasswordHash = passwordHash;
        SecurityStamp = new Guid();
    }

    public void AddRole(ApplicationRole role)
    {
        if (UsersRoles.SingleOrDefault(ur => ur.RoleId == role.Id) is not null)
        {
            // throw new UserAlreadyHaveSelectedRole();
        }
        UserRole userRole = new UserRole(this, role);//todo: 
        UsersRoles.Add(userRole);
    }

    public void AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshTokens.Add(refreshToken);
    }

    public void IncrementAccessFailedCount()
    {
        AccessFailedCount += 1;
    }

    public void ResetAccessFailedCount()
    {
        AccessFailedCount = 0;
        LockoutEnd = null;
    }

    public void ConfirmPhoneNumber()
    {
        PhoneNumberConfirmed = true;
    }
    
    public void ConfirmEmail()
    {
        EmailConfirmed = true;
    }
    
    public IEnumerable<string> GetPermissionsList()
    {
        return UsersRoles.SelectMany(x => x.Role.RolesPermissionSets)
            .Select(x => x.PermissionSet)
            .Distinct()
            .SelectMany(x => x.PermissionPermissionSet)
            .Select(x => x.Permission.Name)
            .Distinct();
    }

    public bool CheckIfRefreshTokenIsValid(string refreshToken)
    {
        RefreshTokenValue refreshTokenValue = new (Encoding.UTF8.GetBytes(refreshToken));
        return CheckIfRefreshTokenIsValid(refreshTokenValue);
    }
    public bool CheckIfRefreshTokenIsValid(byte[] refreshToken)
    {
        RefreshTokenValue refreshTokenValue = new(refreshToken);
        return CheckIfRefreshTokenIsValid(refreshTokenValue);
    }

    public bool CheckIfRefreshTokenIsValid(RefreshTokenValue refreshToken)
    {
        return RefreshTokens
            .Any(x => x.ValidTo >= DateTime.UtcNow && refreshToken.Equals(x.Token));
    }

    public void GenerateNewSecurityStamp()
    {
        SecurityStamp = new Guid();
    }
}

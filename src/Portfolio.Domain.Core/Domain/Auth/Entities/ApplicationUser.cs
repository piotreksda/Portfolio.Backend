using Microsoft.AspNetCore.Identity;
using Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects;
using Portfolio.Domain.Core.Domain.Core.Primitives;
using Portfolio.Domain.Core.Domain.Entites;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class ApplicationUser : BaseAuditableEntity<int>
{
    private ApplicationUser()
    {
        
    }

    public ApplicationUser(string userName, Email email)
    {
        UserName = userName;
        Email = email;
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

    public virtual ICollection<UserRole> UsersRoles { get; private set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; private set; }

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
}

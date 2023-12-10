using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities;

public class RefreshToken : BaseAuditableEntity<int>
{
    private RefreshToken()
    {
        
    }

    public RefreshToken(ApplicationUser user, RefreshTokenValue token, DateTime validTo)
    {
        User = user;
        Token = token;
        ValidTo = validTo;
    }
    
    public virtual ApplicationUser User { get; private set; }
    public int UserId { get; private set; }
    public RefreshTokenValue Token { get; private set; }
    public DateTime ValidTo { get; private set; }
    
}
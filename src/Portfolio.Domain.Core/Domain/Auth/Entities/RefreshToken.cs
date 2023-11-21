using Portfolio.Domain.Core.Domain.Core.Primitives;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class RefreshToken : BaseAuditableEntity<int>
{
    public virtual ApplicationUser User { get; private set; }
    public int UserId { get; private set; }
    public byte[] Token { get; private set; }
    public DateTime ValidTo { get; private set; }
}
using Portfolio.Domain.Core.Domain.Core.Primitives;

namespace Portfolio.Domain.Core.Domain.Auth.Entities;

public class LoginHistory : BaseEntity<int>
{
    public virtual ApplicationUser User { get; private set; }
    public int UserId { get; private set; }
    public DateTime Date { get; private set; }
    public string IpAddress { get; private set; }
    public string? Location { get; private set; }
    
}
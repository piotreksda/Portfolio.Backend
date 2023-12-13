using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Core.Entities;

public class ActionToken : BaseAuditableEntity<int>
{
    private ActionToken()
    {
        
    }

    public ActionToken(int userId, string token)
    {
        UserId = userId;
        Token = token;
    }
    public string Token { get; private set; }
    public bool Used { get; private set; }
    public int UserId { get; private set; }
    public virtual ApplicationUser User { get; private set; }

    public void UseToken()
    {
        Used = true;
    }
}
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Core.Entities;

public class SmtpConfiguration : BaseAuditableEntity<int>
{
    public string Host { get; private set; }
    public int Port { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool EnableSsl { get; private set; }
    public string SendFrom { get; private set; }
}
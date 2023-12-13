using System.IdentityModel.Tokens.Jwt;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Infrastructure.Persistance;

public class IdentityContext : IIdentityContext
{
    private readonly IJwtTokenService _jwtTokenService;

    public IdentityContext(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public int? UserId { get; private set; }
    public string? TokenString { get; private set; }
    public JwtSecurityToken Token { get; private set; }
    public List<string> Permissions { get; private set; }
    // public bool TokenIsValid { get; private set; }

    private bool configured { get; set; } = false;
    
    public async Task Configure(string tokenString)
    {
        if (configured)
        {
            throw new Exception();
        }

        Token = new JwtSecurityToken(tokenString);

        Permissions = Token.Claims.Where(x => x.Type == ClaimsTypes.PermissionListClaim).Select(x => x.Value).ToList();

        UserId = int.Parse(Token.Claims.Single(x => x.Type == ClaimsTypes.UserIdClaim).Value);

        configured = true;
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Entities;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.BadRequestExceptions;
using Portfolio.Shared.Kernel.Infrastructure.Utils;


namespace Portfolio.Shared.Kernel.Infrastructure.Services;

public class ActionTokenService : IActionTokenService
{
    private readonly IConfiguration _configuration;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IActionTokenRepository _tokenRepository;
    public ActionTokenService(IConfiguration configuration, IJwtTokenService jwtTokenService, IActionTokenRepository tokenRepository)
    {
        _configuration = configuration;
        _jwtTokenService = jwtTokenService;
        _tokenRepository = tokenRepository;
    }
    public async Task<string> GenerateActionToken(ActionTokenTypes type, int userId)
    {
        var handler = new JwtSecurityTokenHandler();
        
        var tokenValue = GeneralTools.GenerateRandomString();

        ActionToken actionToken = new(userId, tokenValue);

        await _tokenRepository.AddAsync(actionToken);
        
        var token = GenereateJwtToken(type, userId, tokenValue);
        
        return handler.WriteToken(token);
    }

    private JwtSecurityToken GenereateJwtToken(ActionTokenTypes type, int userId, string value)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:ActionJwtKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new (ClaimsTypes.UserIdClaim, userId.ToString()),
            new (ClaimsTypes.ActionToken, value),
            new Claim(ClaimsTypes.ActionTokenType, type.ToString())
        };
        JwtSecurityToken token = new (
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );
        return token;
    }

    public async Task<int> ValidateActionToken(ActionTokenTypes type, string jwtToken, bool markUsed)
    {
        IEnumerable<Claim> claims = await _jwtTokenService.CheckIfTokenIsValidAndReturnCalms(jwtToken, _configuration["Jwt:ActionJwtKey"]);
        
        (int tokenUserId, string tokenValue, string tokenType) = GetUserAndValueFromClaims(claims);

        if (type.ToString() != tokenType)
        {
            throw new ActionTokenInvalidTypeException();
        }
        
        ActionToken actionToken = await _tokenRepository.GetByUserIdAndValue(tokenUserId, tokenValue);

        if (actionToken.Used)
        {
            throw new ActionTokenAlreadyUsedException();
        }
        
        if (markUsed)
        {
            actionToken.UseToken();
            await _tokenRepository.Update(actionToken);
        }
        
        return tokenUserId;
    }

    private (int, string, string) GetUserAndValueFromClaims(IEnumerable<Claim> claims)
    {
        int.TryParse(claims.SingleOrDefault(x => x.Type == ClaimsTypes.UserIdClaim)?.Value, out int tokenUserId);

        string tokenValue = claims.SingleOrDefault(x => x.Type == ClaimsTypes.ActionToken)?.Value;
        
        string tokenType = claims.SingleOrDefault(x => x.Type == ClaimsTypes.ActionTokenType)?.Value;
        
        return (tokenUserId, tokenValue, tokenType);
    }
    
    
}
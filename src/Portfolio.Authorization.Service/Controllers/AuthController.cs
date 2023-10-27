using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Portfolio.Domain.Core.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Portfolio.Authorization.Service.Controllers;

public class AuthController: ControllerBase
{
    private readonly IConfiguration _configuration;
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet("[controller]/test")]
    [PermissionAuth("test")]
    public async Task<IActionResult> test(){
        return Ok();
    }
    [HttpPost("[controller]/login")]
    public async Task<IActionResult> Login()
    {
        // var user = await _userManager.FindByNameAsync(model.Username);
        // if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        // {
        //     var claims = new[]
        //     {
        //         new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        //         new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
        //         // Możesz dodać więcej roszczeń według potrzeb
        //     };

        //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //     var token = new JwtSecurityToken(
        //         _configuration["Jwt:Issuer"],
        //         _configuration["Jwt:Audience"],
        //         claims,
        //         expires: DateTime.Now.AddMinutes(30),
        //         signingCredentials: creds
        //     );

        //     return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        // }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, "1"),
            new Claim(JwtRegisteredClaimNames.UniqueName, "piotreksda"),
            new Claim("LanguageId", "1")
            // Możesz dodać więcej roszczeń według potrzeb
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: creds
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

        return BadRequest("Invalid credentials");
    }
    
}

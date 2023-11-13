using MediatR;
using Portfolio.Authorization.Service.Application.Commands;
using Portfolio.Authorization.Service.Domain.Dtos;

namespace Portfolio.Authorization.Service.Application.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginDto>
{
    public Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        // var user = await _userManager.FindByNameAsync(model.Username);
        // if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        // {
        //     var claims = new[]
        //     {
        //         new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        //         new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
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

        // var claims = new[]
        // {
        //     new Claim(JwtRegisteredClaimNames.Sub, "1"),
        //     new Claim(JwtRegisteredClaimNames.UniqueName, "piotreksda"),
        //     new Claim("LanguageId", "1")
        // };

        // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        // var token = new JwtSecurityToken(
        //     _configuration["Jwt:Issuer"],
        //     _configuration["Jwt:Audience"],
        //     claims,
        //     expires: DateTime.Now.AddMinutes(2),
        //     signingCredentials: creds
        // );

        // return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

        // return BadRequest("Invalid credentials");
    }
}

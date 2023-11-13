using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Authorization.Service.Application.Commands;
using Portfolio.Authorization.Service.Domain.Dtos;
using Portfolio.Authorization.Service.Domain.Entites.Models;
using Portfolio.Domain.Core.Infrastructure.Extensions;

namespace Portfolio.Authorization.Service.Application.Controllers;

[Route("api")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("[controller]/login")]
    public async Task<ActionResult<LoginDto>> Login(
        [FromBody] LoginInputModel loginInput
    )
    {
        LoginUserCommand request = new (loginInput, HttpContext.GetLanguageId());

        LoginDto result = await _mediator.Send(request);

        return result;
    }
    [HttpPost("[controller]/logout")]
    public async Task<ActionResult<bool>> Logout()
    {
        LogOutUserCommand request = new ();

        bool result = await _mediator.Send(request);

        return result;
    }
    [HttpPost("[controller]/register")]
    public async Task<ActionResult<bool>> Register()
    {
        RegisterUserCommand request = new ();

        bool result = await _mediator.Send(request);

        return result;
    }
    [HttpPost("[controller]/refreshToken")]
    public async Task<ActionResult<bool>> RefreshToken()
    {
        RefreshTokenCommand request = new ();

        bool result = await _mediator.Send(request);

        return result;
    }

    
}

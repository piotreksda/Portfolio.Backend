using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Authorization.Service.Application.ConfirmEmail;
using Portfolio.Authorization.Service.Application.ValidateActionToken;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AdmiController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdmiController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("[controller]/ConfirmEmail")]
    public async Task<ActionResult<bool>> ConfirmEmail([FromBody] string token)
    {
        ConfirmEmailCommand request = new ConfirmEmailCommand(token);
        
        bool result = await _mediator.Send(request);
        
        return result;
    }
    
    [HttpPost("[controller]/ResetPassword")]
    public async Task<ActionResult<bool>> ResetPassword([FromBody] string token, string password)
    {
        return true;
    }

    [HttpGet("[controller]/ValidateActionToken")]
    public async Task<ActionResult<bool>> ValidateActionToken([FromQuery] string token, ActionTokenTypes actionType)
    {
        ValidateActionTokenQuery request = new ValidateActionTokenQuery(token, actionType);
        
        bool result = await _mediator.Send(request);
        
        return result;
    }


}
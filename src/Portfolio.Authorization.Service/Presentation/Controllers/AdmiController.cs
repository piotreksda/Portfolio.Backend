using Microsoft.AspNetCore.Mvc;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AdmiController : ControllerBase
{
    [HttpPost("[controller]/ConfirmEmail")]
    public async Task<ActionResult<bool>> ConfirmEmail([FromBody] string token)
    {
        return true;
    }
    
    [HttpPost("[controller]/ResetPassword")]
    public async Task<ActionResult<bool>> ResetPassword([FromBody] string token, string password)
    {
        return true;
    }

    [HttpGet("[controller]/ValidateActionToken")]
    public async Task<ActionResult<bool>> ValidateActionToken([FromQuery] string token, ActionTokenTypes actionType)
    {
        return true;
    }


}
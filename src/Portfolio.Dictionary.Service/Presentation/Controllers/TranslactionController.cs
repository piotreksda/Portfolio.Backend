using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Shared.Kernel.Domain.Core.Models;

namespace Portfolio.Dictionary.Service.Presentation.Controllers;

[Route("api/dict/[Controller]")]
[ApiController]
public class TranslactionController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public TranslactionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Get list of all translations by language ID
    /// </summary>
    /// <returns>List of TranslationDto</returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet()]
    [ProducesResponseType(type: typeof(Object), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Object>>> GetTranslations()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost()]
    [ProducesResponseType(type: typeof(Object), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Object>> CreateTranslation()
    {
        throw new NotImplementedException();
    }
    
    [HttpPut()]
    [ProducesResponseType(type: typeof(Object), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Object>> EditTranslation()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete()]
    [ProducesResponseType(type: typeof(Object), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(type: typeof(ExceptionModel), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Object>> DeleteTranslation()
    {
        throw new NotImplementedException();
    }
}
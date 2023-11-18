using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Core.Domain.Constants;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;
using Portfolio.Domain.Core.Domain.Core.Exceptions.UnauthorizedExceptions;
using Portfolio.Domain.Core.Domain.Core.Models;
using Portfolio.Domain.Core.Presentation.Extensions;

namespace Portfolio.Domain.Core.Presentation.PipelineBehaviours;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
            
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int languageId = context.GetLanguageId();
        int statusCode = GetStatusCode(exception);

        context.Response.ContentType = ContentType.ApplicationJson;
        context.Response.StatusCode = statusCode;

        ExceptionModel response = new ExceptionModel
        {
            Status = statusCode,
            Title = GetTitle(exception),
            Message = GetMessage(exception),
            ForceAction = GetForceAction(exception)
        };

        string payload = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(payload);
    }

    private string GetTitle(Exception exception)
    {
        string? titleTranslationKey = "";
        if (exception is PortfolioApplicationException appExc)
        {
            titleTranslationKey = appExc?.Title;
            if (titleTranslationKey == null)
                titleTranslationKey = ExceptionsTranslationsKeys.DefaultErrorTitle;
        }
        else
        {
            titleTranslationKey = ExceptionsTranslationsKeys.DefaultErrorTitle;
        }

        string title = null;//here will be translation

        return title ?? titleTranslationKey;
    }

    private string GetMessage(Exception exception)
    {
        return "";
    }

    private ForceFrontExceptionAction GetForceAction(Exception exception)
    {
        return exception switch
        {
            ForbiddenException => ForceFrontExceptionAction.NoAction,
            TokenExpiredException => ForceFrontExceptionAction.RefreshToken,
            UnauthorizedException => ForceFrontExceptionAction.Logout,
            _ => ForceFrontExceptionAction.NoAction
        };
    }

    private int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            ForbiddenException => StatusCodes.Status403Forbidden,
            NotFoundException => StatusCodes.Status404NotFound,
            InvalidStateException => StatusCodes.Status409Conflict,
            PortfolioApplicationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}

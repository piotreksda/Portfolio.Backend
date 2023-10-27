using System.Net;
using System.Text.Json;
using Portfolio.Domain.Core.Domain.Exceptions;
using Portfolio.Domain.Core.Domain.Models;
using Portfolio.Domain.Core.Infrastructure.Contatints;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Portfolio.Domain.Core.Application.PipelineBehaviors;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private int _languageId = DefaultSettings.DefaultLangId;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            //context.Request.EnableBuffering();
            if (context.Request.Headers.TryGetValue("languageId", out var languageStrId))
            {
                if (!string.IsNullOrEmpty(languageStrId))
                {
                    _languageId = Convert.ToInt32(languageStrId);

                    // bool langExist = await _checkLanguageService.CheckLanguageExists(_languageId);
                    // if (!langExist)
                    // {
                    //     _languageId = DefaultSettings.DefaultLangId;
                    //     throw new BadRequestException(ErrorsTrKeys.validationLanguageNotExist);
                    // }
                }
                else
                    throw new BadRequestException(ExceptionsTranslationsKeys.ValidationLanguageNotExist);
            }
            context.Items.Add("languageId", _languageId);
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
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
        return context.Response.WriteAsync(payload);
    }

    private string GetTitle(Exception exception)
    {
        string titleTranslationKey = "";
        if (exception is PortfolioApplicationException appExc)
        {
            titleTranslationKey = appExc?.Title;
            if (titleTranslationKey == null)
                titleTranslationKey = "";
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
            ForbiddenException => ForceFrontExceptionAction.RefreshToken,
            _ => ForceFrontExceptionAction.NoAction
        };
    }

    private int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            ForbiddenException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}

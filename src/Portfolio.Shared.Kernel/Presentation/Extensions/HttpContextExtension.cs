using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.BadRequestExceptions;

namespace Portfolio.Shared.Kernel.Presentation.Extensions;

public static class HttpContextExtension
{
    public static int GetLanguageId (this HttpContext httpContext)
    {
        int languageId = DefaultSettings.DefaultLangId;
        
        if (httpContext.Request.Headers.TryGetValue(HeadersKeys.LanguageId, value: out StringValues langIdFromHeaders))
        {
            int? value = Int32.TryParse(langIdFromHeaders, out int langInt) ? langInt : null;
            languageId = value ?? languageId;
        }
        else
        {
            httpContext.Items.Add(HeadersKeys.LanguageId, languageId);
        }
        return languageId;
    }
    
    public static string GetEmailOriginLink (this HttpContext httpContext)
    {
        
        if (httpContext.Request.Headers.TryGetValue(HeadersKeys.MailOriginLink, value: out StringValues mailOriginLink))
        {
            return mailOriginLink;
        }
        
        throw new EmailOriginLinkWasNotFoundException();
    }
}

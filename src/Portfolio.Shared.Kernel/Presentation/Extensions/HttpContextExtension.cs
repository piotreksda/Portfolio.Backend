using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Presentation.Extensions;

public static class HttpContextExtension
{
    public static int GetLanguageId (this HttpContext httpContext)
    {
        int languageId = DefaultSettings.DefaultLangId;
        
        if (httpContext.Request.Headers.TryGetValue("LanguageId", value: out StringValues langIdFromHeaders))
        {
            int? value = Int32.TryParse(langIdFromHeaders, out int langInt) ? langInt : null;
            languageId = value ?? languageId;
        }
        else
        {
            httpContext.Items.Add("LanguageId", languageId);
        }
        return languageId;
    }
}

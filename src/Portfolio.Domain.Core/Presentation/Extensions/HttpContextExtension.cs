using Microsoft.AspNetCore.Http;
using Portfolio.Domain.Core.Domain.Constants;

namespace Portfolio.Domain.Core.Presentation.Extensions;

public static class HttpContextExtension
{
    public static int GetLanguageId (this HttpContext httpContext)
    {
        int languageId = DefaultSettings.DefaultLangId;
        
        if (httpContext.Items.TryGetValue("LanguageId", value: out var langIdFromHeaders))
        {
            languageId = (int?)langIdFromHeaders ?? languageId;
        }
        else
        {
            httpContext.Items.Add("LanguageId", languageId);
        }
        return languageId;
    }
}

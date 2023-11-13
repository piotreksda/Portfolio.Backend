using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Core.Infrastructure.Extensions;

public static class HttpContextExtension
{
    public static int GetLanguageId (this HttpContext httpContext)
    {
        int languageId = 1;
        if (httpContext.Items.ContainsKey("LanguageId"))
        {
            languageId = (int)httpContext.Items["LanguageId"];
        }
        return languageId;
    }
}

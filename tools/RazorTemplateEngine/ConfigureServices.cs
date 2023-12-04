using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorTemplateEngine.Services;

namespace RazorTemplateEngine;

public static class ConfigureServices
{
    public static IServiceCollection AddRazorTemplateEngine(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRazorPages()
            .AddApplicationPart(typeof(IRazorViewToStringRenderer).Assembly)
            .AddRazorRuntimeCompilation();
        
        return services;
    }
}
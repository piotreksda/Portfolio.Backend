using System.Data.Common;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;
using Portfolio.Shared.Kernel.Infrastructure.Services;
using RazorTemplateEngine;
using RazorTemplateEngine.Abstractions;
using RazorTemplateEngine.Services;

namespace Portfolio.Shared.Kernel;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(o => o.AddPolicy("SpecificOrigins", builder =>
        {
            builder
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        }));

        var connectionStringBuilder = new DbConnectionStringBuilder
        {
            { "Server", configuration["DB_HOST"] ?? string.Empty },
            { "Database", configuration["DB_NAME"] ?? string.Empty }, 
            { "Port", configuration["DB_PORT"] ?? string.Empty },
            { "Username", configuration["DB_USER"] ?? string.Empty },
            { "Password", configuration["DB_PASSWORD"] ?? string.Empty },
            { "Keepalive", configuration["DB_KEEPALIVE"] ?? string.Empty }
        };

        services.AddDbContext<PortfolioDbContext>(options =>
                options.UseNpgsql(
                                // connectionStringBuilder.ConnectionString,
                                "Server=localhost;Database=PortfolioDev;Port=5433;Username=postgres;Password=postgres;Keepalive=60",
                                b => b.MigrationsAssembly(typeof(PortfolioDbContext).Assembly.FullName)));
            services.AddScoped<PortfolioDbContextInitializer>();
            
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });

        services.AddRouting(o =>
        {
            o.LowercaseUrls = true;
            o.LowercaseQueryStrings = true;
        });

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });

        services.AddRazorTemplateEngine(configuration);
        
        services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
        services.AddScoped<IEmailTranslationService, EmailTranslationService>();
        services.AddScoped<ISmtpConfigurationService, SmtpConfigurationService>();

        services.AddScoped<SmtpClient>(serviceProvider =>
        {
            var smtpConfigService = serviceProvider.GetRequiredService<ISmtpConfigurationService>();
            var smtpConfig = smtpConfigService.GetSmtpConfigurationAsync().Result;

            var client = new SmtpClient(smtpConfig.Host)
            {
                Port = smtpConfig.Port,
                Credentials = new NetworkCredential(smtpConfig.Username, smtpConfig.Password),
                EnableSsl = smtpConfig.EnableSsl
            };

            return client;
        });

        services.AddScoped<IEmailService, EmailService>();
        
        return services;
    }
}

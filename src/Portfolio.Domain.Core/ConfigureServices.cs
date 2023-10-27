using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data.Common;
using Portfolio.Domain.Core.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Portfolio.Domain.Core.Domain.Entities;

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
            { "Server", configuration["DB_HOST"] },
            { "Database", configuration["DB_NAME"] },
            { "Port", configuration["DB_PORT"] },
            { "Username", configuration["DB_USER"] },
            { "Password", configuration["DB_PASSWORD"] },
            { "Keepalive", configuration["DB_KEEPALIVE"] }
        };
        //"Server=localhost;Database=PortfolioDev;Port=5433;Username=postgres;Password=postgres;Keepalive=60"
        //connectionStringBuilder.ConnectionString
        services.AddDbContext<PortfolioDbContext>(options =>
                options.UseNpgsql(
                                "Server=localhost;Database=PortfolioDev;Port=5433;Username=postgres;Password=postgres;Keepalive=60",
                                b => b.MigrationsAssembly(typeof(PortfolioDbContext).Assembly.FullName)));
            services.AddScoped<PortfolioDbContextInitializer>();

        services.AddIdentity<ApplicationUser, ApplicationRole>(opt => 
                {
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireNonAlphanumeric = true;

                    opt.Lockout.AllowedForNewUsers = true; // default is true
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // default is 5
                    opt.Lockout.MaxFailedAccessAttempts = 3; // default is 5
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                    opt.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<PortfolioDbContext>()
                .AddDefaultTokenProviders();

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

        return services;
    }
}

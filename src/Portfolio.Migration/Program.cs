using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Shared.Kernel;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Infrastructure.Persistance;
using Portfolio.Shared.Kernel.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<IIdentityContext, IdentityContext>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
var app = builder.Build();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
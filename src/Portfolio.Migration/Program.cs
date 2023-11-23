using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Core;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Infrastructure.Persistance;
using Portfolio.Domain.Core.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<IIdentityContext, IdentityContext>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
var app = builder.Build();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
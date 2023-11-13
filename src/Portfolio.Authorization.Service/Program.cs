using Portfolio.Domain.Core.Domain.Entities;
using Portfolio.Domain.Core.Application.PipelineBehaviors;
using Portfolio.Domain.Core.Infrastructure.Services;
using Portfolio.Domain.Core.Infrastructure.Services.Interfaces;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Portfolio.Domain.Core;
using Portfolio.Domain.Core.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Portfolio.Dictionary.Service"
        });
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
            $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    });

builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/healthz");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<PortfolioDbContextInitializer>();
    await initializer.InitializeAsync();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

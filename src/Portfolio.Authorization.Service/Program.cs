using Portfolio.Domain.Core.Infrastructure.Services;
using Portfolio.Domain.Core.Infrastructure.Services.Interfaces;
using System.Reflection;
// using FluentValidation;
using Microsoft.OpenApi.Models;
using Portfolio.Domain.Core;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Infrastructure.Repositories;
using Portfolio.Domain.Core.Presentation.PipelineBehaviours;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


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
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

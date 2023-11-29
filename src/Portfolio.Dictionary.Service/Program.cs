using System.Reflection;
// using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models;
using Portfolio.Domain.Core;
using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Infrastructure.Services;
using Portfolio.Domain.Core.Presentation.PipelineBehaviours;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
// builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<PortfolioDbContextInitializer>();
await initializer.InitializeAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("SpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

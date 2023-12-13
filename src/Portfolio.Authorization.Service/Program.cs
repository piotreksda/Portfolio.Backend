using Portfolio.Shared.Kernel.Infrastructure.Services;
using System.Reflection;
// using FluentValidation;
using Microsoft.OpenApi.Models;
using Portfolio.Shared.Kernel;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Infrastructure.Persistance;
using Portfolio.Shared.Kernel.Infrastructure.Repositories;
using Portfolio.Shared.Kernel.Presentation.PipelineBehaviours;

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


builder.Services.AddScoped<IIdentityContext, IdentityContext>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IActionTokenRepository, ActionTokenRepository>();
builder.Services.AddTransient<IActionTokenService, ActionTokenService>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddTransient<AddIdentityContextMiddleware>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(UnitOfWorkBehaviour<,>));
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHealthChecks();

var app = builder.Build();
app.MapHealthChecks("/healthz");

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<PortfolioDbContextInitializer>();
await initializer.InitializeAsync();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AddIdentityContextMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("SpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

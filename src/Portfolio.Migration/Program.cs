using Microsoft.AspNetCore.Builder;
using Portfolio.Domain.Core.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
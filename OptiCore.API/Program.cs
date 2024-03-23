using Opticore.Infrastructure;
using Opticore.Persistence;
using OptiCore.Application;
using Auth.DependencyInjection.Injection;
using Auth.Core.Models.Configuration;
using static OptiCore.API.Constants.Constants;
using Auth.Core.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthServices(auth =>
{
    auth
    .WithTokenValidation(builder.Configuration)
    .WithCache(CacheConfiguration.Default);
});
builder.Services.AddInternalAuthServer();

builder.Services.AddControllers();
var corsOrigins = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.CORSOrigins) ?? 
    builder.Configuration[ConfigurationKeys.AppSettings.CORSOrigins] ?? "*";
builder.Services.AddCors(options =>
{
    options.AddPolicy(DefaultCorsPolicy, builder => builder
    .AllowCredentials()
    .WithOrigins(corsOrigins.Split(','))
    .AllowAnyHeader()
    .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(DefaultCorsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseAuthorization();

app.Run();
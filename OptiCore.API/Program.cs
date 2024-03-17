using Opticore.Infrastructure;
using Opticore.Persistence;
using OptiCore.Application;
using Auth.DependencyInjection.Injection;
using Auth.Core.Models.Configuration;
using Auth.Core.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
GoogleOAuthConfiguration googleOAuth = new GoogleOAuthConfiguration
{
    ClientId = "fake",
    ClientSecret = "123",
    LoginPath = "here"
};
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthServices(builder =>
{
    builder
    .WithGoogleOAuthConfiguration(googleOAuth)
    .WithCache(CacheConfiguration.Default);
});
builder.Services.AddInternalAuthServer();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
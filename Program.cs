global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.EntityFrameworkCore;
using System.Text;
using learning_asp.Data;
using learning_asp.Interface;
using learning_asp.Model;
using learning_asp.Options;
using learning_asp.Repository;
using learning_asp.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database //
var connectionString = config.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Dependency injection //

// Singleton (Per server)
// Singleton is a single instance for all requests
builder.Services.AddSingleton<ILog, ConsoleLogger>();
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

// AddScoped (Per request)
// AddScoped is for multiple instances per request
builder.Services.AddScoped<DealershipRepository, DealershipRepository>();
builder.Services.AddScoped<UserRepository, UserRepository>();

// Transient (Per injections)
// Transient is multiple instances per layer per request or injection

// JWT Setup //
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


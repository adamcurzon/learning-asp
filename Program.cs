using learning_asp.Data;
using learning_asp.Interface;
using learning_asp.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection //

// Singleton (Per server)
// Singleton is a single instance for all requests
builder.Services.AddSingleton<ILog, ConsoleLogger>();

// AddScoped (Per request)
// AddScoped is for multiple instances per request
// builder.Services.AddScoped<ILog, ConsoleLogger>();

// Transient (Per injections)
// Transient is multiple instances per layer per request or injection


// Database //
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(connectionString); 
});

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


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.IServices;
using Serilog;

using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/agenda_log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddScoped<ILogger<AgendaLogger<T>>;


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

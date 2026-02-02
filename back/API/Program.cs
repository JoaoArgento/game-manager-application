using Microsoft.EntityFrameworkCore;
using Infra.Data;
using Application.Services;
using Domain.Repositories;

DotNetEnv.Env.Load("../.env");

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PostgresContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_URL"));
});

Console.WriteLine($"Variavel de ambiente: {Environment.GetEnvironmentVariable("POSTGRES_URL")} ");

// foreach (var envVar in Environment.GetEnvironmentVariables())
// {
//     Console.WriteLine(envVar);
// }

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

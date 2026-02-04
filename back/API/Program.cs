using Microsoft.EntityFrameworkCore;
using Infra.Data;
using Domain.Repositories;
using Application.Services;


var builder = WebApplication.CreateBuilder(args);

// if (!builder.Environment.IsEnvironment("Testing"))
// {
//     DotNetEnv.Env.Load("../.env");
// }

builder.Services.AddDbContext<PostgresContext>(options =>
{
    string ? connectionString = builder.Configuration.GetConnectionString("Postgres");
    options.UseNpgsql(connectionString);
});


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
app.MapControllers();
app.Run();

public partial class Program
{
    
}


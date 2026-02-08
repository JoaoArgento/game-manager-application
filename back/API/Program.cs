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

builder.Services.AddCors(options =>
{
   options.AddPolicy("frontend", policy =>
   {
      policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
   });
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
app.UseCors("frontend");
app.MapControllers();
app.Run();

public partial class Program
{
    
}


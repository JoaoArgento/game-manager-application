using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace Infra.Data;


public class PostgresContextFactory : IDesignTimeDbContextFactory<PostgresContext>
{
    public PostgresContext CreateDbContext(string[] args)
    {
        string ? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{env}.json", optional: true).Build();

        string ? connection  = config.GetConnectionString("Postgres");
        var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();

        optionsBuilder.UseNpgsql(connection);

        return new PostgresContext(optionsBuilder.Options);

    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
namespace Infra.Data;


public class PostgresContextFactory : IDesignTimeDbContextFactory<PostgresContext>
{
    public PostgresContext CreateDbContext(string[] args)
    {
        DotNetEnv.Env.Load("../.env");

        string ? connection  = Environment.GetEnvironmentVariable("POSTGRES_URL");
        var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();

        optionsBuilder.UseNpgsql(connection);

        return new PostgresContext(optionsBuilder.Options);

    }
}

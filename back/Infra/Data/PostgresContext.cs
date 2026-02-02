using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infra.Data;


public class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

     public DbSet<Game> Games => Set<Game>();

    

}
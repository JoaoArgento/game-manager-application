using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;

public class GameRepository : IGameRepository
{
    private readonly PostgresContext context;

    public GameRepository(PostgresContext postgresContext)
    {
        this.context = postgresContext;
    }

    public bool CanConnectToDB() => context.Database.CanConnect();
        
    public async Task AddAsync(Game game)
    {
        // string insertSQL = @"INSERT INTO games (name, description) 
        //                     VALUES(@Name, @Description) RETURNING *";

    
        await context.Games.AddAsync(game);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await context.Games.ToListAsync();
    }

    public async Task<Game?> GetOneByIdAsync(Guid id)
    {
        return await context.Games.FindAsync(id);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
    
        Game? target = await GetOneByIdAsync(id) 
        ?? throw new NullReferenceException($"Game with id {id} doesnt exist");

        context.Games.Remove(target);
        await context.SaveChangesAsync();
    }

    public async Task<Game> UpdateByIdAsync(Guid id, string name, string description, string logoPath)
    {
        Game ? target = await GetOneByIdAsync(id);

        if (target == null)
        {
            throw new NullReferenceException($"Game with id {id} doesnt exist");
        }
        target.Update(name, description, logoPath, 0);
        return target;
    }
}
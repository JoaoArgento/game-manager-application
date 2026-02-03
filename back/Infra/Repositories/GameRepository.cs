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
    private readonly PostgresContext postgresContext;

    public GameRepository(PostgresContext postgresContext)
    {
        this.postgresContext = postgresContext;
    }

    public bool CanConnectToDB() => postgresContext.Database.CanConnect();
        
    public async Task AddAsync(Game game)
    {
        // string insertSQL = @"INSERT INTO games (name, description) 
        //                     VALUES(@Name, @Description) RETURNING *";

    
        await postgresContext.Games.AddAsync(game);
        await postgresContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await postgresContext.Games.ToListAsync();
    }

    public async Task<Game?> GetOneByIdAsync(Guid id)
    {
        Game ? game = await postgresContext.Games.FindAsync(id);
        return game;
    }

    public async Task RemoveByIdAsync(Guid id)
    {
        Game ? target = await GetOneByIdAsync(id);

        if (target == null)
        {
            return;
        }
        postgresContext.Games.Remove(target);
        await postgresContext.SaveChangesAsync();
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
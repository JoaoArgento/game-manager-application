using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data;


public class GameRepository : IGameRepository
{
    private readonly PostgresContext postgresContext;

    public GameRepository(PostgresContext postgresContext)
    {
        this.postgresContext = postgresContext;
    }
    public async Task AddAsync(Game game)
    {
        // string insertSQL = @"INSERT INTO games (name, description) 
        //                     VALUES(@Name, @Description) RETURNING *";

    
        await postgresContext.Games.AddAsync(game);
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return [.. postgresContext.Games];
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

    public Task UpdateByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
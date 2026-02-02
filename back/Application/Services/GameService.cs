using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class GameService
{
    private readonly IGameRepository gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public async Task CreateGame(string name, string description)
    {
        Game newGame = new Game(Guid.NewGuid(), name, description, Genre.Action);
        await gameRepository.AddAsync(newGame);

    }
}
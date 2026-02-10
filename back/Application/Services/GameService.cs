using Application.DTOs;
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

    public async Task<Game> CreateGame(CreateGameRequest createGameRequest)
    {
        Game newGame = new Game(Guid.NewGuid(), createGameRequest.Name, 
                                                createGameRequest.Description, 
                                                createGameRequest.LogoPath, 
                                                Genre.Action);
        await gameRepository.AddAsync(newGame);

        return newGame;
    }

    public async Task<Game> UpdateGame(UpdateGameRequest updateGameRequest)
    {
        var updatedGame  = await gameRepository.UpdateByIdAsync(
                                updateGameRequest.Id, 
                                updateGameRequest.Name,
                                updateGameRequest.Description,
                                updateGameRequest.LogoPath);

        return updatedGame;
    }

    public async Task DeleteGameAsync(string id)
    {
        try
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                throw new ArgumentException("id invalido");
            }
            await gameRepository.DeleteByIdAsync(guid);         
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    public async Task<IEnumerable<Game>> GetAllAsync() => await gameRepository.GetAllAsync();
}
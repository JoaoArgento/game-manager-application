using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("games")]
public class GameDataController : ControllerBase
{
    private readonly GameService gameService;

    public GameDataController(GameService gameService)
    {
        this.gameService = gameService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Game> allGames = [.. (await gameService.GetAllAsync())];
        
        return Ok(allGames);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateGameRequest createGameRequest)
    {
        Game newGame = await gameService.CreateGame(createGameRequest);
        return Ok(newGame);
    }
    [HttpPatch]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateGameRequest updateGameRequest)
    {
        var updatedGame = await gameService.UpdateGame(updateGameRequest);
        return Ok(updatedGame);
    }

    
}
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
        List<Game> allGames = (await gameService.GetAllAsync()).ToList();
        
        return Ok(new {message = "Foi aos prantos o gay", CanConnect = gameService.CanConnectToDB()});
    }

    // [HttpPost]
    // public async Task<IActionResult> AddAsync()
    // {
    //     await gameService.CreateGame("Yes baby", "thankYou");

    //     return Ok();
    // }

    
}
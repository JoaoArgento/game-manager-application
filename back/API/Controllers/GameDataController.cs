using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("games")]
public class GameDataController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(new {message = "Estavão ta demais!"});
    }

    
}
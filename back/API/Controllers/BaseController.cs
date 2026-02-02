using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("/")]
public class IndexController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(new {message = "Ola!"});
    }
}

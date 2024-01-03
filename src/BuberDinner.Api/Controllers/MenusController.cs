using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
public class MenusController : ApiController
{
    [HttpPost("{hostId:guid}/menus")]
    public IActionResult CreateMenu([FromRoute] Guid hostId)
    {
        return Ok(Array.Empty<string>());
    }
}
using Microsoft.AspNetCore.Mvc;
namespace webapiPizzaStore.Controllers;

[ApiController]
[Route("[controller]")]
public class BaceController:ControllerBase
{
    [HttpGet]
[Route("TestAuthorization")]
public IActionResult TestAuthorization()
{
    var roleClaim = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
    return Ok($"Your role is: {roleClaim}");
}
    
}
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
    var claims = User.Claims.Select(c => $"{c.Type}: {c.Value}").ToList();
    return Ok($"Claims: {string.Join(", ", claims)}");
}  
}
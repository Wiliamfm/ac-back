using AzureChallenge.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AzureChallenge.Api.Controllers.Authentication;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
  [HttpPost("register")]
  public IActionResult Register([FromBody] RegisterRequest request)
  {
    return Ok(request);
  }

  [HttpPost("login")]
  public IActionResult Login([FromBody] LoginRequest request)
  {
    return Ok(request);
  }
}

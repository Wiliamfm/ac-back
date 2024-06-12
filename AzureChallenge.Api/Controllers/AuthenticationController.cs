using AzureChallenge.Application.Services.Authentication;
using AzureChallenge.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AzureChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
  private readonly IAuthenticationService _authenticationService= authenticationService;

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequest request)
  {
    var authResult = await _authenticationService.Register(request.Email, request.FirstName, request.LastName, request.Password);
    var response = new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.Email,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.Token);

    return Ok(response);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequest request)
  {
    var authResult = await _authenticationService.Login(request.Email, request.Password);
    var response = new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.Email,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.Token);

    return Ok(response);
  }
}

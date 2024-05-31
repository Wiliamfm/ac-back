using AzureChallenge.Application.Common.Interfaces;

namespace AzureChallenge.Application.Services.Authentication;

public class AuthenticationService(IJwtGenerator jwtGenerator) : IAuthenticationService
{
  private readonly IJwtGenerator _jwtGenerator= jwtGenerator;

  public Task<AuthenticationResult> Register(string email, string firstName, string lastName, string password)
  {
    var userId = 0;
    var token = _jwtGenerator.GenerateToken(userId, email, firstName, lastName);
    return Task.FromResult<AuthenticationResult>(new AuthenticationResult(0, "email", "firstName", "lastName", token));
  }

  public Task<AuthenticationResult> Login(string email, string password)
  {
    return Task.FromResult<AuthenticationResult>(new AuthenticationResult(0, "email", "firstName", "lastName", "token"));
  }
}

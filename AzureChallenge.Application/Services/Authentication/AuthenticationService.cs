using AzureChallenge.Application.Interfaces;
using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Services.Authentication;

public class AuthenticationService(IJwtGenerator jwtGenerator, IUserRepository userRepository) : IAuthenticationService
{
  private readonly IJwtGenerator _jwtGenerator= jwtGenerator;
  private readonly IUserRepository _userRepository= userRepository;

  public async Task<AuthenticationResult> Register(string email, string firstName, string lastName, string password)
  {
    if(await _userRepository.GetUserByEmailAsync(email) is not null)
    {
      throw new ArgumentException("Email is already in use.");
    }
    var user = new User()
    {
      Email = email,
      FirstName = firstName,
      LastName = lastName,
      Password = password
    };
    var token = _jwtGenerator.GenerateToken(user);
    var response = new AuthenticationResult(user, token);
    return response;
  }

  public async Task<AuthenticationResult> Login(string email, string password)
  {
    var user = await _userRepository.GetUserByEmailAsync(email);
    if(user is null)
    {
      throw new ArgumentException("User does not exist.");
    }
    //TODO: Change to hashed password verification.
    if(user.Password != password)
    {
      throw new ArgumentException("Password is incorrect.");
    }
    var token = _jwtGenerator.GenerateToken(user);
    var response = new AuthenticationResult(user, token);
    return response;
  }
}

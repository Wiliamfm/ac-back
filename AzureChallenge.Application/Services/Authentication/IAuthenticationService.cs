namespace AzureChallenge.Application.Services.Authentication;

public interface IAuthenticationService
{
  Task<AuthenticationResult> Register(string email, string firstName, string lastName, string password);

  Task<AuthenticationResult> Login(string email, string password);
}

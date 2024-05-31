namespace AzureChallenge.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public Task<AuthenticationResult> Register(string email, string firstName, string lastName, string password)
    {
        return Task.FromResult<AuthenticationResult>(new AuthenticationResult(0, "email", "firstName", "lastName", "token"));
    }

    public Task<AuthenticationResult> Login(string email, string password)
    {
        return Task.FromResult<AuthenticationResult>(new AuthenticationResult(0, "email", "firstName", "lastName", "token"));
    }
}

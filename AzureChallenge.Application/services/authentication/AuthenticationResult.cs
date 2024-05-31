namespace AzureChallenge.Application.Services.Authentication;

public record AuthenticationResult
(
  int Id,
  string Email,
  string FirstName,
  string LastName,
  string Token
);

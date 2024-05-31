namespace AzureChallenge.Contracts.Authentication;

public record AuthenticationResponse
(
  int Id,
  string Email,
  string firstName,
  string lastName,
  string Token
);

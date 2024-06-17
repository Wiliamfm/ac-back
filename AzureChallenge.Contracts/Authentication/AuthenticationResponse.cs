namespace AzureChallenge.Contracts.Authentication;

public record AuthenticationResponse
(
  int Id,
  string Email,
  string FirstName,
  string LastName,
  string Roles,
  string Token
);

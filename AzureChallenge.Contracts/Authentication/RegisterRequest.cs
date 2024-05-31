namespace AzureChallenge.Contracts.Authentication;

public record RegisterRequest
(
  string Email,
  string FirstName,
  string LastName,
  string Password
);

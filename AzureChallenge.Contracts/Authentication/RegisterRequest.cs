namespace AzureChallenge.Contracts.Authentication;

public record RegisterRequest
(
  string Email,
  string firstName,
  string lastName,
  string Password
);

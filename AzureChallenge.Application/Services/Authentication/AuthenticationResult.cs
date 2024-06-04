using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Services.Authentication;

public record AuthenticationResult
(
  User User,
  string Token
);

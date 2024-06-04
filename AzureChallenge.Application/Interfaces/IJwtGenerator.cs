using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Interfaces;

public interface IJwtGenerator
{
  public string GenerateToken(User user);
}

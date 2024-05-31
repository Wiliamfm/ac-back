namespace AzureChallenge.Application.Common.Interfaces;

public interface IJwtGenerator
{
  public string GenerateToken(int userId, string email, string firstName, string lastName);
}

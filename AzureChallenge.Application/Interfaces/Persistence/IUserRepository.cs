using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Interfaces.Persistence;

public interface IUserRepository
{
  Task AddUserAsync(User user);
  Task<User?> GetUserByEmailAsync(string email);
}

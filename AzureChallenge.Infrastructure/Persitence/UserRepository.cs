using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
  private static readonly List<User> _users = new();

  public Task AddUserAsync(User user)
  {
    _users.Add(user);
    return Task.CompletedTask;
  }

  public Task<User?> GetUserByEmailAsync(string email)
  {
    Console.WriteLine(email);
    foreach (var user in _users)
    {
      Console.WriteLine(user);
    }
    return Task.FromResult(_users.SingleOrDefault(x => x.Email == email));
  }
}

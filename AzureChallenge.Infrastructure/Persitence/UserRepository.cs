using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;
using AzureChallenge.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace AzureChallenge.Infrastructure.Persistence;

public class UserRepository(AzureChallengeDbContext dbContext) : IUserRepository
{
    private readonly AzureChallengeDbContext _dbContext = dbContext;

    public async Task AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email == email);
    }
}

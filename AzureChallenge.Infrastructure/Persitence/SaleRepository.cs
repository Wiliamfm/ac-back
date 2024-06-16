using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Infrastructure.Persitence;

public class SaleRepository(AzureChallengeDbContext dbContext) : ISaleRepository
{
  private readonly AzureChallengeDbContext _dbContext = dbContext;

    public async Task<Sale> CreateAsync(Sale sale)
    {
      var s = await _dbContext.Sales.AddAsync(sale);
      await _dbContext.SaveChangesAsync();
      return s.Entity;
    }
}

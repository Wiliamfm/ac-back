using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;
using AzureChallenge.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace AzureChallenge.Infrastructure.Persistence;

public class ProductRepository(AzureChallengeDbContext dbContext) : IProductRepository
{
    private readonly AzureChallengeDbContext _dbContext = dbContext;

    public async Task<Product> CreateAsync(Product product)
    {
        var p= await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return p.Entity;
    }

    public async Task<Product?> GetAsync(int? id = null, string? name = null)
    {
      return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id || x.Name == name);
    }

    public async Task<IEnumerable<Product>> GetListAsync()
    {
      return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product> UpdateAsync(Product product)
    {
      await _dbContext.SaveChangesAsync();
      return product;
    }
}

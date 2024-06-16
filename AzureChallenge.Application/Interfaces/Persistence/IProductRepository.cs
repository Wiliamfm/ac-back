using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Interfaces.Persistence;

public interface IProductRepository
{
  Task<IEnumerable<Product>> GetListAsync();
  Task<Product?> GetAsync(int? id = null, string? name = null);
  Task<Product> CreateAsync(Product product);
  Task<Product> UpdateAsync(Product product);
}

using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Interfaces;

public interface IProductsService
{
  Task<IEnumerable<Product>> GetListAsync();
  Task<Product?> GetAsync(int id);
  Task<Product> CreateAsync(string name, string description, decimal price, int stock);
  Task<Product> AddProductAsync(int productId, int quantity);
  Task<Sale> SellProductsAsync(Dictionary<int, int> products, int vendorId, int clientId);
  Task<IEnumerable<Report>> GenerateReportAsync(DateTime startDate, DateTime endDate);
}

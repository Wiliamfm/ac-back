using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Interfaces.Persistence;

public interface IReportRepository
{
  Task<Report> CreateAsync(int adminId, int productId, DateTime startDate, DateTime endDate, int currentStock, double rating, bool isTrending, float trendingPercentage, string comment);
}

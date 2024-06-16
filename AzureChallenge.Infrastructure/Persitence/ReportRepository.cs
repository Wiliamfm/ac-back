using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Infrastructure.Persitence;

public class ReportRepository : IReportRepository
{
    public Task<Report> CreateAsync(int adminId, int productId, DateTime startDate, DateTime endDate, int currentStock, double rating, bool isTrending, float trendingPercentage, string comment)
    {
        throw new NotImplementedException();
    }
}

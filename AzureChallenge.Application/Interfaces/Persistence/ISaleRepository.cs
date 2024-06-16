using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Interfaces.Persistence;

public interface ISaleRepository
{
  Task<Sale> CreateAsync(Sale sale);
}

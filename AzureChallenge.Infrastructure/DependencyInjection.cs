using AzureChallenge.Application.Interfaces;
using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Infrastructure.Security;
using AzureChallenge.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureChallenge.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
  {
    services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

    services.AddSingleton<IJwtGenerator, JwtGenerator>();

    services.AddScoped<IUserRepository, UserRepository>();
    return services;
  }
}

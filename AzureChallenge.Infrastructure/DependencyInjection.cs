using AzureChallenge.Application.Common.Interfaces;
using AzureChallenge.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureChallenge.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
  {
    services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

    services.AddSingleton<IJwtGenerator, JwtGenerator>();
    return services;
  }
}

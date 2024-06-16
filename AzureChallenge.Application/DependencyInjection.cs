using AzureChallenge.Application.Interfaces;
using AzureChallenge.Application.Services.Authentication;
using AzureChallenge.Application.Services.Products;
using Microsoft.Extensions.DependencyInjection;

namespace AzureChallenge.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<IProductsService, ProductsService>();
    return services;
  }
}

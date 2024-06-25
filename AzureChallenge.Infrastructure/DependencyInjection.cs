using AzureChallenge.Application.Interfaces;
using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Infrastructure.Security;
using AzureChallenge.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using AzureChallenge.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Azure.Identity;

namespace AzureChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSecrets(configuration);
        services.AddAuth(configuration);
        services.AddDb(configuration);

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtGenerator, JwtGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = jwtSettings.Issuer,
                  ValidAudience = jwtSettings.Audience,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
              };
          });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value.Contains("admin"))));
            options.AddPolicy("ManagerOnly", policy => policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value.Contains("manager"))));
            options.AddPolicy("EmployeeOnly", policy => policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value.Contains("employee"))));
        });


        return services;
    }

    public static IServiceCollection AddDb(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<AzureChallengeDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        return services;
    }

    public static IServiceCollection AddSecrets(this IServiceCollection services, ConfigurationManager configuration)
    {
        configuration.AddAzureKeyVault(
            new Uri($"{configuration["KeyVaultUri"]}"),
            new DefaultAzureCredential()
        );

        return services;
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AzureChallenge.Infrastructure.Persitence;

public static class DatabasesMigrator
{
    public async static Task MigrateApplicationDatabaseAsync(this WebApplication app)
    {
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("DB");

        logger.LogInformation("Starting migration of application database...");

        try
        {
            using var scope = app.Services.CreateScope();
            var appDbContext = scope.ServiceProvider.GetRequiredService<AzureChallengeDbContext>();
            await appDbContext.Database.MigrateAsync();
            logger.LogInformation("Migration of application database completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Migration of application database failed.");
            throw;
        }
    }
}

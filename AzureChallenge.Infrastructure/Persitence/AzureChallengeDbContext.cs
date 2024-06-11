using AzureChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureChallenge.Infrastructure.Persitence;

public sealed class AzureChallengeDbContext(DbContextOptions<AzureChallengeDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(options =>
        {
            options.ToTable("Users");
            options.HasKey(u => u.Id);
        });
    }

}

using AzureChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureChallenge.Infrastructure.Persitence;

public sealed class AzureChallengeDbContext(DbContextOptions<AzureChallengeDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO: Add attributes to column (decimal precision, max length, etc).
        modelBuilder.Entity<User>(options =>
        {
            options.ToTable("Users");
            options.HasKey(u => u.Id);

            List<User> users = [
              new User
              {
                  Id = 1,
                  Email = "admin@example.com",
                  FirstName = "William",
                  LastName = "Admin"
              },
              new User
              {
                  Id = 2,
                  Email = "manager@example.com",
                  FirstName = "William",
                  LastName = "Manager"
              },
              new User
              {
                  Id = 3,
                  Email = "employee@example.com",
                  FirstName = "William",
                  LastName = "Employee"
              },
            ];

            users.ForEach(u => u.SetPassword("P@ssw0rd"));
            options.HasData(users);

            options.HasMany(u => u.Roles).WithMany().UsingEntity("User_Role")
            .HasData([
              new { UserId = 1, RolesId = 1 },
              new { UserId = 1, RolesId = 2 },
              new { UserId = 2, RolesId = 2 },
              new { UserId = 3, RolesId = 3 },
            ]);

        });
        modelBuilder.Entity<Role>(options =>
        {
            options.ToTable("Roles");
            options.HasKey(r => r.Id);

            options.HasData([
              new Role { Id = 1, Name = RoleName.Admin.ToString() },
              new Role { Id = 2, Name = RoleName.Manager.ToString() },
              new Role { Id = 3, Name = RoleName.Employee.ToString() },
              //new Role { Id = 1, Name = RoleName.User.ToString() },
            ]);
        });
        modelBuilder.Entity<Product>(options =>
        {
            options.ToTable("Products");
            options.HasKey(p => p.Id);

            options.HasData([
                new Product { Id = 1, Name = "Product 1", Description = "Product 1 description", Price = 100, Stock = 10 },
                new Product { Id = 2, Name = "Product 2", Description = "Product 2 description", Price = 200, Stock = 20 },
            ]);
        });
        modelBuilder.Entity<Report>(options =>
        {
            options.ToTable("Reports");
            options.HasKey(r => r.Id);
            options.HasOne<User>().WithMany().HasForeignKey(r => r.AdminId).OnDelete(DeleteBehavior.NoAction);
            options.HasOne<Product>().WithMany().HasForeignKey(r => r.ProductId).OnDelete(DeleteBehavior.NoAction);
        });
        modelBuilder.Entity<Sale>(options =>
        {
            options.ToTable("Sales");
            options.HasKey(s => s.Id);
            options.HasOne<User>().WithMany().HasForeignKey(s => s.VendorId).OnDelete(DeleteBehavior.NoAction);
            options.HasMany(s => s.Products).WithMany().UsingEntity("Sale_Product");
            //options.HasOne<User>().WithMany().HasForeignKey(s => s.ClientId).OnDelete(DeleteBehavior.NoAction);
        });
    }

}

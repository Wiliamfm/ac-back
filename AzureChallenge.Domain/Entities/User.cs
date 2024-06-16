using Microsoft.AspNetCore.Identity;

namespace AzureChallenge.Domain.Entities;

public class User
{
  public int Id { get; set; }
  public string Email { get; set; } = null!;
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string Password { get; private set; } = null!;
  public ICollection<Role> Roles { get; } = new List<Role>();

  public string SetPassword(string password, IPasswordHasher<User> passwordHasher = null!)
  {
    passwordHasher ??= new PasswordHasher<User>();
    Password = passwordHasher.HashPassword(this, password);
    return Password;
  }

  public bool VerifyPassword(string password, IPasswordHasher<User> passwordHasher)
  {
    return passwordHasher.VerifyHashedPassword(this, Password, password) == PasswordVerificationResult.Success;
  }

  public override string ToString()
  {
    return $"{Id}:{Email} - {FirstName} {LastName}\nRoles:\n{(Roles.Any() ? Roles.Select(x => x.Name.ToLower()).Aggregate((x, y) => $"{x}\n{y}") : "There is no roles")}";
  }
}

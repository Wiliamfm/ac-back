using Microsoft.AspNetCore.Identity;

namespace AzureChallenge.Domain.Entities;

public class User
{
  public int Id { get; set; }
  public string Email { get; set; } = null!;
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string Password { get; private set; } = null!;

  public string SetPassword(string password, IPasswordHasher<User> passwordHasher)
  {
    Password = passwordHasher.HashPassword(this, password);
    return Password;
  }

  public bool VerifyPassword(string password, IPasswordHasher<User> passwordHasher)
  {
    return passwordHasher.VerifyHashedPassword(this, Password, password) == PasswordVerificationResult.Success;
  }

  public override string ToString()
  {
    return $"{Id}:{Email} - {FirstName} {LastName}";
  }
}

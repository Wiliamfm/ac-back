namespace AzureChallenge.Domain.Entities;

public class User
{
  public int Id { get; set; }
  public string Email { get; set; } = null!;
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string Password { get; set; } = null!;

  public override string ToString()
  {
    return $"{Id}:{Email} - {FirstName} {LastName}";
  }
}

namespace AzureChallenge.Domain.Entities;

public class Role
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
}

public enum RoleName
{
  Admin,
  Manager,
  Employee,
  //User
}

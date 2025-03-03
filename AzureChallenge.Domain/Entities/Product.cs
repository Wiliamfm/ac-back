namespace AzureChallenge.Domain.Entities;

public class Product
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public decimal Price { get; set; }
  public int Stock { get; set; }

  public void AddStock(int quantity)
  {
    Stock += quantity;
  }

  public void RemoveStock(int quantity)
  {
    Stock -= quantity;
  }

  public bool ValidateStock(int quantity)
  {
    return Stock >= quantity;
  }
}

namespace AzureChallenge.Domain.Entities;

public class Sale
{
  public int Id { get; set; }
  public ICollection<Product> Products { get; set; } = null!;
  public int VendorId { get; set; }
  public string ClientId { get; set; } = null!;
  public decimal Price { get; set; }
  public int Quantity { get; set; }
  public DateTime Date { get; set; }
  public string? Notes { get; set; }

  public Sale(int vendorId, string clientId)
  {
    VendorId = vendorId;
    ClientId = clientId;
    Products = new List<Product>();
    Date = DateTime.UtcNow;
  }
}

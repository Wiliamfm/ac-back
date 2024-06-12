namespace AzureChallenge.Domain.Entities;

public class Report
{
  public int Id { get; set; }
  public int AdminId { get; set; }
  public int ProductId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public DateTime CreationDate { get; set; }
  public int CurrentStock { get; set; }
  public double Rating { get; set; }
  public bool IsTrending { get; set; }
  public float TrendingPercentage { get; set; }
  public string Comment { get; set; } = null!;
}

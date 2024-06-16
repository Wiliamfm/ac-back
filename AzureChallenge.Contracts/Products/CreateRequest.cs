namespace AzureChallenge.Contracts.Products;

public record CreateRequest
(
  string Name,
  string Description,
  decimal Price,
  int Stock
);

public record AddStockRequest
(
  int Quantity
);

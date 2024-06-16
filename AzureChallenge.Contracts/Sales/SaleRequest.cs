namespace AzureChallenge.Contracts.Sales;

public record ProductsSaleRequest
(
 Dictionary<int, int> Products,
 int VendorId,
 int CustomerId
);

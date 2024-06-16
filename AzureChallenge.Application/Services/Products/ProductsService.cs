using AzureChallenge.Application.Interfaces;
using AzureChallenge.Application.Interfaces.Persistence;
using AzureChallenge.Domain.Entities;

namespace AzureChallenge.Application.Services.Products;

public class ProductsService(IProductRepository productRepository, ISaleRepository saleRepository, IReportRepository reportRepository) : IProductsService
{
  //TODO: Implement UnitOfWork.
    private readonly IProductRepository _productRepository= productRepository;
    private readonly ISaleRepository _saleRepository= saleRepository;
    private readonly IReportRepository _reportRepository= reportRepository;

    public async Task<Product> AddProductAsync(int productId, int quantity)
    {
        var product = await _productRepository.GetAsync(id: productId);
        if(product is null) throw new ArgumentException("Product does not exist.");
        product.AddStock(quantity);
        product = await _productRepository.UpdateAsync(product);
        return product;
    }

    public async Task<Product> CreateAsync(string name, string description, decimal price, int stock)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
        if(string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description is required.");
        if(price < 0) throw new ArgumentException("Price cannot be negative.");
        if(stock < 0) throw new ArgumentException("Stock cannot be negative.");
        if(await _productRepository.GetAsync(name: name) is not null) throw new ArgumentException("Product already exists.");
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock
        };
        return await _productRepository.CreateAsync(product);
    }

    public Task<IEnumerable<Report>> GenerateReportAsync(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetAsync(int id)
    {
        return _productRepository.GetAsync(id: id);
    }

    public async Task<IEnumerable<Product>> GetListAsync()
    {
        return await _productRepository.GetListAsync();
    }

    public async Task<Sale> SellProductsAsync(Dictionary<int, int> products, int vendorId, int clientId)
    {
      var sale = new Sale(vendorId: vendorId, clientId: clientId.ToString());
      foreach(var product in products)
      {
        if(product.Value < 0) throw new ArgumentException($"Quantity cannot be negative for product {product.Key}.");
        if(product.Value == 0) continue;
        var p = await _productRepository.GetAsync(id: product.Key);
        if(p is null) throw new ArgumentException($"Product {product.Key} does not exist.");
        if(p.ValidateStock(product.Value) is false) throw new ArgumentException($"Not enough stock for product {product.Key}.");
        sale.Quantity += product.Value;
        sale.Price += p.Price;
        p.RemoveStock(product.Value);
        sale.Products.Add(p);
      }
      sale = await _saleRepository.CreateAsync(sale);
      Console.WriteLine($"\nSale created with total price: {sale.Price} -- {sale.Products.Count()} products.");  
      return sale;
    }
}

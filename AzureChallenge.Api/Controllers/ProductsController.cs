using AzureChallenge.Application.Interfaces;
using AzureChallenge.Contracts.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController(IProductsService productService): ControllerBase
{
  private readonly IProductsService _productService = productService;

  [HttpGet]
  [AllowAnonymous]
  public async Task<IActionResult> GetProducts()
  {
    var products = await _productService.GetListAsync();
    return Ok(products);
  }

  [HttpGet("{id}")]
  [AllowAnonymous]
  public async Task<IActionResult> GetProduct(int id)
  {
    var product = await _productService.GetAsync(id);
    return Ok(product);
  }

  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] CreateRequest request)
  {
    var product = await _productService.CreateAsync(request.Name, request.Description, request.Price, request.Stock);
    return Ok(product);
  }

  [HttpPost("{id}/stock")]
  public async Task<IActionResult> AddStock(int id, [FromBody] AddStockRequest request)
  {
    var product = await _productService.AddProductAsync(id, request.Quantity);
    return Ok(product);
  }
}

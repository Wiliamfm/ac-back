using AzureChallenge.Application.Interfaces;
using AzureChallenge.Contracts.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class SalesController(IProductsService productsService) : ControllerBase
{
  private readonly IProductsService _productsService = productsService;

  [HttpGet]
  public async Task<IActionResult> GetSales()
  {
    //var sales = await _salesRepository.GetListAsync();
    return Ok(Array.Empty<object>());
  }

  [HttpPost]
  [Authorize(Policy = "AdminOnly, ManagerOnly, EmployeeOnly")]
  public async Task<IActionResult> CreateSale([FromBody] ProductsSaleRequest request)
  {
    var sale = await _productsService.SellProductsAsync(request.Products, request.VendorId, request.CustomerId);
    return Ok(sale);
  }
}

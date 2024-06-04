using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AzureChallenge.Api.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{

  [Route("error")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public IActionResult Error()
  {
    var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    var statusCode = exception switch
    {
      ArgumentException => 400,
      _ => 500
    };

    return Problem(title: exception?.Message, statusCode: statusCode);
  }
}

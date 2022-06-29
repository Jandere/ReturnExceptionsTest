using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ReturnExceptionsTest.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    protected IActionResult Handle<T>(Result<T> result)
        where T : class
    {
        if (result.Exception != null)
        {
            return result.Exception switch
            {
                ArgumentNullException => StatusCode(400, result.Exception.Message),
                ArgumentException => StatusCode(400, result.Exception.Message),
                InvalidOperationException => StatusCode(500, result.Exception.Message),
                _ => StatusCode(500, result.Exception.Message)
            };
        }

        return Ok(result.Item);
    }
}
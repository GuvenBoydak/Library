using Library.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult CustomActionResult<T>(ResponseDto<T> response)
    {
        if (response.StatusCode == 204)
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode,
            };

        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode,
        };
    }
}
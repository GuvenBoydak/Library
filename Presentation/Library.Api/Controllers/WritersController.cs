using Library.Application.Features.Command.Writer.AddWriter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

public class WritersController : BaseController
{
    private readonly IMediator _mediator;

    public WritersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddWriterCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }
}
using Library.Application.Features.Command.Writer.AddWriter;
using Library.Application.Features.Queries.Writer.GetAllWriters;
using Library.Application.Features.Queries.Writer.GetByIdsWriters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;


public class WritersController : BaseController
{
    private readonly IMediator _mediator;

    public WritersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllWritersQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddWriterCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetByIds([FromBody] GetByIdsWritersQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }
}
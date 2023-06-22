using Library.Application.Features.Command.User.LoginUser;
using Library.Application.Features.Command.User.RegisterUser;
using Library.Application.Features.Queries.User.GetByEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

public class UsersController : BaseController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Email}")]
    public async Task<IActionResult> GetByEmail([FromRoute] GetByEmailQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }
}
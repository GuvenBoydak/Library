using Library.Application.Features.Command.Order.AddOrder;
using Library.Application.Features.Queries.Order.GetOrdersByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

public class OrdersController : BaseController
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetOrdersByUserId([FromRoute]GetOrdersByUserIdQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]AddOrderCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }
}
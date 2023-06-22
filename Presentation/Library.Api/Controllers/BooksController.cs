using Library.Application.Features.Command.Book.AddBook;
using Library.Application.Features.Queries.Book.GetAllBook;
using Library.Application.Features.Queries.Book.GetByIdBook;
using Library.Application.Features.Queries.Book.GetByIdsBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

public class BooksController : BaseController
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllBooksQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpGet("[action]/{Id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBookQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetByIds([FromBody] GetByIdsBooksQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBookCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }
}
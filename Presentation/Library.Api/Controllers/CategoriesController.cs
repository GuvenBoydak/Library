using Library.Application.Features.Command.Category.AddCategory;
using Library.Application.Features.Queries.Category.GetAllCategory;
using Library.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

public class CategoriesController : BaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GetAllCategoryQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpGet("[action]/{Id:guid}")]
    public async Task<IActionResult> GetById([FromRoute]GetByIdCategoryQuery request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]AddCategoryCommand request)
    {
        var response = await _mediator.Send(request);
        return CustomActionResult(response);
    }
}
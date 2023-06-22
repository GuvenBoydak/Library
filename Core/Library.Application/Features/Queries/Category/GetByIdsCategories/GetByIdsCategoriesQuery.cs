using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using MediatR;

namespace Library.Application.Features.Queries.Category.GetByIdsCategories
{
    public record GetByIdsCategoriesQuery(List<Guid> Ids) : IRequest<ResponseDto<List<CategoryListDto>>>;
}

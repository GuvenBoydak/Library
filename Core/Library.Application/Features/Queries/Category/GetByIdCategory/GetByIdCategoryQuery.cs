using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using MediatR;

namespace Library.Application.Features.Queries.Category.GetByIdCategory;

public record GetByIdCategoryQuery(Guid Id) : IRequest<ResponseDto<CategoryDto>>;
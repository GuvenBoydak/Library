using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using MediatR;

namespace Library.Application.Features.Queries.Category.GetAllCategory;

public record GetAllCategoriesQuery : IRequest<ResponseDto<List<CategoryListDto>>>;
using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using MediatR;

namespace Library.Application.Features.Command.Category.AddCategory;

public record AddCategoryCommand(string Name) : IRequest<ResponseDto<CategoryDto>>;
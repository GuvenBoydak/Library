using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Category.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, ResponseDto<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<CategoryDto>> Handle(GetByIdCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        return ResponseDto<CategoryDto>.Success(_mapper.Map<Domain.Entities.Category, CategoryDto>(category), 200);
    }
}
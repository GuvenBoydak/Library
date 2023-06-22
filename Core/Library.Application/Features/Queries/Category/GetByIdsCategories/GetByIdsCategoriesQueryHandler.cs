using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Category.GetByIdsCategories
{
    public class GetByIdsCategoriesQueryHandler : IRequestHandler<GetByIdsCategoriesQuery, ResponseDto<List<CategoryListDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdsCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CategoryListDto>>> Handle(GetByIdsCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetByIdsAsync(x => request.Ids.Contains(x.Id));

            return ResponseDto<List<CategoryListDto>>.Success(_mapper.Map<List<Domain.Entities.Category>, List<CategoryListDto>>(categories), 200);
        }
    }
}

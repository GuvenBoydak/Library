using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using Library.Application.Repositories;
using Library.Application.UnitOfWork;
using MediatR;

namespace Library.Application.Features.Command.Category.AddCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ResponseDto<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto<CategoryDto>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<AddCategoryCommand, Domain.Entities.Category>(request);

        var categoryDto =
            _mapper.Map<Domain.Entities.Category, CategoryDto>(await _categoryRepository.AddAsync(category));

        await _unitOfWork.SaveChanges();
        return ResponseDto<CategoryDto>.Success(categoryDto, 200);
    }
}
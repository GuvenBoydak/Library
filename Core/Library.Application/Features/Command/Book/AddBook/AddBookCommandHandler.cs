using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Repositories;
using Library.Application.UnitOfWork;
using MediatR;

namespace Library.Application.Features.Command.Book.AddBook;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, ResponseDto<BookDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto<BookDto>> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<AddBookCommand, Domain.Entities.Book>(request);

        var result = await _bookRepository.AddAsync(book);

        await _unitOfWork.SaveChanges();
        return ResponseDto<BookDto>.Success(_mapper.Map<Domain.Entities.Book, BookDto>(result), 200);
    }
}
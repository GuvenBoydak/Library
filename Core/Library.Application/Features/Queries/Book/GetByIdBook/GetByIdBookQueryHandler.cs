using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetByIdBook;

public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, ResponseDto<BookDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetByIdBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<BookDto>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        return ResponseDto<BookDto>.Success(_mapper.Map<Domain.Entities.Book, BookDto>(book), 200);
    }
}
using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Features.Queries.Book.GetAllBook;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Writer.GetAllWriters;

public class GetAllWritersQueryHandler : IRequestHandler<GetAllBooksQuery, ResponseDto<List<BookListDto>>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetAllWritersQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<List<BookListDto>>> Handle(GetAllBooksQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync();

        return ResponseDto<List<BookListDto>>.Success(_mapper.Map<List<Domain.Entities.Book>, List<BookListDto>>(books),
            200);
    }
}
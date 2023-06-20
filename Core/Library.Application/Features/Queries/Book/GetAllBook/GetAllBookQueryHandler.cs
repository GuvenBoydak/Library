using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetAllBook;

public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, ResponseDto<List<BookListDto>>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetAllBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<List<BookListDto>>> Handle(GetAllBookQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync();

        return ResponseDto<List<BookListDto>>.Success(_mapper.Map<List<Domain.Entities.Book>, List<BookListDto>>(books),
            200);
    }
}
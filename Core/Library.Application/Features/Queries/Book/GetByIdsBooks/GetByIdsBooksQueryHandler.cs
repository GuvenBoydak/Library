using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetByIdsBook
{
    public class GetByIdsBooksQueryHandler : IRequestHandler<GetByIdsBooksQuery, ResponseDto<List<BookListDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetByIdsBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<BookListDto>>> Handle(GetByIdsBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetByIdsAsync(x => request.Ids.Contains(x.Id));

            return ResponseDto<List<BookListDto>>.Success(_mapper.Map<List<Domain.Entities.Book>, List<BookListDto>>(books), 200);
        }
    }
}

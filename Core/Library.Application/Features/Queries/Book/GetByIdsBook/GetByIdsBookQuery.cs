using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetByIdsBook
{
    public record GetByIdsBookQuery(List<Guid> Ids) : IRequest<ResponseDto<List<BookListDto>>>;

    public class GetByIdsBookQueryHandler : IRequestHandler<GetByIdsBookQuery, ResponseDto<List<BookListDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetByIdsBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Task<ResponseDto<List<BookListDto>>> Handle(GetByIdsBookQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.Where(x => request.Ids.Contains(x.Id)).ToList();

            return Task.FromResult(ResponseDto<List<BookListDto>>.Success(_mapper.Map<List<Domain.Entities.Book>, List<BookListDto>>(books), 200));
        }
    }
}

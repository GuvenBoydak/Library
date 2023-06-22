using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetByIdsBook
{
    public record GetByIdsBooksQuery(List<Guid> Ids) : IRequest<ResponseDto<List<BookListDto>>>;
}

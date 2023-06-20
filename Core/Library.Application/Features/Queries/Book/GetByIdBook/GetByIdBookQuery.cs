using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetByIdBook;

public record GetByIdBookQuery(Guid Id) : IRequest<ResponseDto<BookDto>>;
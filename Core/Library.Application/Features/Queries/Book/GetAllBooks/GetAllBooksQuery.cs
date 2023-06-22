using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetAllBook;

public record GetAllBooksQuery : IRequest<ResponseDto<List<BookListDto>>>;
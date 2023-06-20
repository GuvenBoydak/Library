using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetAllBook;

public record GetAllBookQuery : IRequest<ResponseDto<List<BookListDto>>>;
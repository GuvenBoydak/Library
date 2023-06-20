using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Command.Book.AddBook;

public record AddBookCommand
(Guid CategoryId, Guid WriterId, bool IsItInLibrary, string Name,
    string ImageUrl) : IRequest<ResponseDto<BookDto>>;
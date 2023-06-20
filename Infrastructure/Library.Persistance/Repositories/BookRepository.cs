using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Persistance.Context;

namespace Library.Persistance.Repositories;

public class BookRepository:GenericRepository<Book>,IBookRepository
{
    public BookRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}
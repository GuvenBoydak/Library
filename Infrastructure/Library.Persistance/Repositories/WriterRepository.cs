using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Persistance.Context;

namespace Library.Persistance.Repositories;

public class WriterRepository:GenericRepository<Writer>,IWriterRepository
{
    public WriterRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}
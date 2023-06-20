using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Persistance.Context;

namespace Library.Persistance.Repositories;

public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
{
    public CategoryRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}
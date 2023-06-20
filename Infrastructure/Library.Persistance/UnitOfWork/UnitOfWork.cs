using Library.Application.UnitOfWork;
using Library.Persistance.Context;

namespace Library.Persistance.UnitOfWork;

public class UnitOfWork:IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;

    public UnitOfWork(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}
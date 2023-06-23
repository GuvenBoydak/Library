using System.Linq.Expressions;
using Library.Application.Exceptions;
using Library.Application.Repositories;
using Library.Domain;
using Library.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly LibraryDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T model)
    {
        var result = await _dbSet.AddAsync(model);
        return result.Entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var result = await _dbSet.ToListAsync();
        if (result == null)
            throw new NotFoundException($"{typeof(T)} Not Found");

        return result;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null)
            throw new NotFoundException($"{typeof(T)} Not Found");

        return result;
    }

    public async Task<List<T>> GetByIdsAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).ToListAsync();
    }

    public void Update(T model)
    {
        _dbSet.Update(model);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Where(filter);
    }
}
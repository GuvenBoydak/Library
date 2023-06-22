using System.Linq.Expressions;
using Library.Domain;

namespace Library.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T model);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetByIdsAsync(Expression<Func<T, bool>> filter);
    IQueryable<T> Where(Expression<Func<T, bool>> filter);
}
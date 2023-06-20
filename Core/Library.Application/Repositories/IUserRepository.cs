using Library.Domain.Entities;

namespace Library.Application.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email);
}
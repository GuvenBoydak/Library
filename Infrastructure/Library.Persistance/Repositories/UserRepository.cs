using Library.Application.DTOs.User;
using Library.Application.Exceptions;
using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
            throw new NotFoundException("User not Found");

        return user;
    }
}
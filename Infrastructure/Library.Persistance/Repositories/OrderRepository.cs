using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Order>> GetOrdersByUserId(Guid userId)
    {
        return await _dbContext.Set<Order>().Where(x => x.UserId == userId).ToListAsync();
    }
}
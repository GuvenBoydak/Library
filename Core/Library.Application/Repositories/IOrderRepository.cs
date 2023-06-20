using Library.Domain.Entities;

namespace Library.Application.Repositories;

public interface IOrderRepository:IRepository<Order>
{
    Task<List<Order>> GetOrdersByUserId(Guid userId);
}
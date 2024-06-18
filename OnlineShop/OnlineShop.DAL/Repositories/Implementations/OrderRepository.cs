using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderRepository:IBaseRepository<Order>
{
    public Task<Order> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAll()
    {
        throw new NotImplementedException();
    }
}
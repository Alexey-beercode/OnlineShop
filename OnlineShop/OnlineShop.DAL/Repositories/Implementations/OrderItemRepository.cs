using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderItemRepository:IBaseRepository<OrderItem>
{
    public Task<OrderItem> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAll()
    {
        throw new NotImplementedException();
    }
}
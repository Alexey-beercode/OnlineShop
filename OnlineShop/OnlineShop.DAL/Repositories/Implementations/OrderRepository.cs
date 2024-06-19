using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderRepository:IBaseRepository<Order>
{
    public Task<Order> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
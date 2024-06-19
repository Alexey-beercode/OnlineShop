using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderItemRepository:IBaseRepository<OrderItem>
{
    public Task<OrderItem> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
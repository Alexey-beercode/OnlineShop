using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderItemRepository:IBaseRepository<OrderItem>
{
    public Task CreateAsync(OrderItem entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(OrderItem entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderItem entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
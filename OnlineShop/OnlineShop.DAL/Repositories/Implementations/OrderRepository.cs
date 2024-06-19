using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderRepository:IBaseRepository<Order>
{
    public Task CreateAsync(Order entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Order entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class UserRepository:IBaseRepository<User>
{
    public Task<User> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
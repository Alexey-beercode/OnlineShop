using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.DAL.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
}
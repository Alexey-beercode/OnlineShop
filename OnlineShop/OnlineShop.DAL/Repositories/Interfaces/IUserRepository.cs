using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.DAL.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task CreateAsync(User user, CancellationToken cancellationToken = default);
    Task DeleteAsync(User user, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
}
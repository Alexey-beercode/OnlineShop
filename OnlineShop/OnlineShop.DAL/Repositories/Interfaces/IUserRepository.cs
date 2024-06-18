using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.DAL.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task CreateAsync(User user);
    Task DeleteAsync(User user);
    Task UpdateAsync(User user);

    Task<User?> GetByLoginAsync(string login);
}
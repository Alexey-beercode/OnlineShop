using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.DAL.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
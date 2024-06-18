namespace OnlineShop.DAL.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
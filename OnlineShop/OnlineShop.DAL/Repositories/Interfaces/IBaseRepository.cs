namespace OnlineShop.DAL.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
}
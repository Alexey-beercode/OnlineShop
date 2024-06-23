using OnlineShop.BLL.DTO.Responses;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Services.Interfaces;

public interface ICategoryService
{
    Task CreateAsync(string categoryName,CancellationToken cancellationToken);
    Task<CategoriesCollectionResponseDTO> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoryResponseDTO> GetByIdAsync(Guid id,CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);

}
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Services.Interfaces;

public interface ICategoryService
{
    Task CreateAsync(CategoryRequestDTO categoryRequestDto,CancellationToken cancellationToken);
    Task<IEnumerable<CategoryResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoryResponseDTO> GetByIdAsync(Guid id,CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);

}
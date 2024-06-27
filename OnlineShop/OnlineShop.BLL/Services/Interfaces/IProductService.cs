using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;

namespace OnlineShop.BLL.Services.Interfaces;

public interface IProductService
{
    Task CreateAsync(ProductRequestDTO productRequestDto,CancellationToken cancellationToken);
    Task UpdateAsync(ProductUpdateRequestDTO productRequestDto,CancellationToken cancellationToken);
    Task DeleteAsync(Guid id,CancellationToken cancellationToken);
    Task<IEnumerable<ProductResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductResponseDTO> GetByIdAsync(Guid id,CancellationToken cancellationToken);
    Task<IEnumerable<ProductResponseDTO>> GetByCategoryIdAsync(Guid categoryId,CancellationToken cancellationToken);
}
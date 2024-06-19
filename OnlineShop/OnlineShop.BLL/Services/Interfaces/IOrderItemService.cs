using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Services.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemResponseDTO> GetByIdAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default);
    Task<IEnumerable<OrderItemResponseDTO>> GetAllAsync(CancellationToken token = default);
    Task CreateOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default);
    Task UpdateOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default);
    Task DeleteOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default);
    
}
namespace OnlineShop.BLL.Services.Interfaces;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.Controllers;

public interface IOrderService
{
    Task<OrderResponseDTO> CreateOrderAsync(CreateOrderRequestDTO createOrderRequestDTO, CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<OrderResponseDTO> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task CancelOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderResponseDTO>> GetAllAsync(CancellationToken token);
    Task UpdateOrderAsync(Guid id, UpdateOrderRequestDTO request, CancellationToken token);
    Task DeleteOrderAsync(Guid id, CancellationToken token);
}
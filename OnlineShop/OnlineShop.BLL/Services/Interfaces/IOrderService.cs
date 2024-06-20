namespace OnlineShop.BLL.Services.Interfaces;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;

public interface IOrderService
{
    Task<OrderResponseDTO> CreateOrderAsync(CreateOrderRequestDTO createOrderRequestDTO, CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<OrderResponseDTO> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task CancelOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
}
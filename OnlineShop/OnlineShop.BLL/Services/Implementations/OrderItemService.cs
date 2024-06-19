using MapsterMapper;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.BLL.Services.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly IBaseRepository<OrderItem> _orderItemRepository;
    private readonly IMapper _mapper;
    public OrderItemService(ShopDbContext context, IMapper mapper)
    {
        _orderItemRepository = new OrderItemRepository(context);
        _mapper = mapper;
    }
    public async Task CreateOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        try
        {
            var orderItem = _mapper.Map<OrderItem>(requestDTO);
            await _orderItemRepository.CreateAsync(orderItem);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Unable to create order item", ex);
        }
    }

    public async Task DeleteOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        var result = new OrderItemResponseDTO();
        try
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(requestDTO.Id);
            await _orderItemRepository.DeleteAsync(orderItem, token);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Unable to create order item", ex);
        }
    }

    public async Task<IEnumerable<OrderItemResponseDTO>> GetAllAsync(CancellationToken token = default)
    {
        try
        {
            var orderItemsCollection = await _orderItemRepository.GetAllAsync(token);
            if (orderItemsCollection == null)
                throw new ServiceException("Unable to get order items");
            return _mapper.Map<IEnumerable<OrderItemResponseDTO>>(orderItemsCollection);
        }
        catch (ServiceException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new ServiceException(ex.Message, ex);
        }
    }

    public async Task<OrderItemResponseDTO> GetByIdAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        var result = new OrderItemResponseDTO();
        try
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(requestDTO.Id, token);
            if (orderItem == null)
                throw new EntityNotFoundException(nameof(OrderItem), requestDTO.Id);
            _mapper.Map<OrderItemResponseDTO>(result);
        }
        catch (EntityNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new ServiceException(ex.Message, ex);
        }
        return result;
    }


    public async Task UpdateOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        var result = new OrderItemResponseDTO();
        try
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(requestDTO.Id, token);
            _mapper.Map(requestDTO, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem, token);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Unable to create order item", ex);
        }
    }
}
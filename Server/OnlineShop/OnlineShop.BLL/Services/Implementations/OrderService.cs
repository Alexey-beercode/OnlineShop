using Mapster;
using MapsterMapper;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Mappers;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.BLL.Validators;
using OnlineShop.Controllers;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;
namespace OnlineShop.BLL.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponseDTO> CreateOrderAsync(CreateOrderRequestDTO createOrderRequestDTO, CancellationToken cancellationToken = default)
    {
        CreateOrderValidator createOrderValidator = new CreateOrderValidator(_productRepository);
        await createOrderValidator.ValidateAndThrowAsync(createOrderRequestDTO, cancellationToken);

        var orderItems = new List<OrderItem>();
        foreach (var orderItemRequestDTO in createOrderRequestDTO.OrderItems)
        {
            var product = await _productRepository.GetByIdAsync(orderItemRequestDTO.ProductId, cancellationToken);
            if (product is null)
            {
                throw new EntityNotFoundException(nameof(Product), orderItemRequestDTO.ProductId);
            }

            //TODO: Product has no quantity field
            /*if (product.Quantity < orderItemRequestDTO.Quantity)
            {
                throw new ValidationException($"Not enough {product.Name} in stock. Available: {product.Quantity}.");
            }*/

            orderItems.Add(new OrderItem
            {
                Product = product,
                Quantity = orderItemRequestDTO.Quantity,
                
                //TODO: OrderItem has no price field
                /*Price = product.Price*/
            });

            //TODO: Product has no quantity field
            /*product.Quantity -= orderItemRequestDTO.Quantity;*/
            
            await _productRepository.UpdateAsync(product, cancellationToken);
        }

        var order = new Order
        {
            OrderDate = DateTime.UtcNow,
            User = _mapper.Map<User>(createOrderRequestDTO.User),
            OrderItems = orderItems,
        };

        await _orderRepository.CreateAsync(order, cancellationToken);

        var orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
        return orderResponseDTO;
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var orders = await _orderRepository.GetOrdersByUserIdAsync(userId, cancellationToken);

        var ordersResponseDTO = _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
        return ordersResponseDTO;
    }

    public async Task<OrderResponseDTO> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
        {
            throw new EntityNotFoundException(nameof(Order), orderId);
        }

        var orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
        return orderResponseDTO;
    }

    public async Task CancelOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
        {
            throw new EntityNotFoundException(nameof(Order), orderId);
        }

        if (order.IsCancelled)
        {
            throw new OrderAlreadyCancelledException();
        }

        order.IsCancelled = true;
        await _orderRepository.UpdateAsync(order, cancellationToken);
    }
    public async Task<IEnumerable<OrderResponseDTO>> GetAllAsync(CancellationToken token)
    {
        var orders = await _orderRepository.GetAllAsync(token);
        return _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
    }

    public async Task UpdateOrderAsync(Guid id, UpdateOrderRequestDTO updateOrderRequestDTO, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(id, cancellationToken);
        if (order is null)
        {
            throw new EntityNotFoundException(nameof(Order), id);
        }

        var orderItems = new List<OrderItem>();
        foreach (var orderItemRequestDTO in updateOrderRequestDTO.OrderItems)
        {
            var product = await _productRepository.GetByIdAsync(orderItemRequestDTO.ProductId, cancellationToken);
            if (product is null)
            {
                throw new EntityNotFoundException(nameof(Product), orderItemRequestDTO.ProductId);
            }

            //TODO: Product has no quantity field
            /*if (product.Quantity < orderItemRequestDTO.Quantity)
            {
                throw new ValidationException($"Not enough {product.Name} in stock. Available: {product.Quantity}.");
            }*/

            orderItems.Add(new OrderItem
            {
                Product = product,
                Quantity = orderItemRequestDTO.Quantity,
                
                //TODO: OrderItem has no price field
                /*Price = product.Price*/
            });

            //TODO: Product has no quantity field
            /*product.Quantity -= orderItemRequestDTO.Quantity;*/
            await _productRepository.UpdateAsync(product, cancellationToken);
        }

        order.OrderItems = orderItems;
        await _orderRepository.UpdateAsync(order, cancellationToken);
    }

    public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(id, cancellationToken);
        if (order is null)
        {
            throw new EntityNotFoundException(nameof(Order), id);
        }

        await _orderRepository.DeleteAsync(order, cancellationToken);
    }
}
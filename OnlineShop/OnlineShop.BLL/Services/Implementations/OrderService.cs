using Mapster;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Mappers;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.BLL.Validators;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;
namespace OnlineShop.BLL.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        MapsterConfig.Configure();

        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<OrderResponseDTO> CreateOrderAsync(CreateOrderRequestDTO createOrderRequestDTO, CancellationToken cancellationToken = default)
    {
        CreateOrderValidator createOrderValidator = new CreateOrderValidator(_productRepository);
        await createOrderValidator.ValidateAndThrowAsync(createOrderRequestDTO, cancellationToken);

        var orderItems = new List<OrderItem>();
        foreach (var orderItemRequestDTO in createOrderRequestDTO.OrderItems)
        {
            //TODO: link with real realization
            //var product = await _productRepository.GetByIdAsync(orderItemRequestDTO.ProductId, cancellationToken);
            //if (product is null)
            //{
            //    throw new EntityNotFoundException(nameof(Product), orderItemRequestDTO.ProductId);
            //}

            //if (product.Quantity < orderItemRequestDTO.Quantity)
            //{
            //    throw new ValidationException($"Not enough {product.Name} in stock. Available: {product.Quantity}.");
            //}

            //orderItems.Add(new OrderItem
            //{
            //    Product = product,
            //    Quantity = orderItemRequestDTO.Quantity,
            //    Price = product.Price
            //});

            //product.Quantity -= orderItemRequestDTO.Quantity;
            //await _productRepository.UpdateAsync(product, cancellationToken);
        }

        var order = new Order
        {
            OrderDate = DateTime.UtcNow,
            User = createOrderRequestDTO.User.Adapt<User>(),
            OrderItems = orderItems,
        };

        await _orderRepository.CreateAsync(order, cancellationToken);

        var orderResponseDTO = order.Adapt<OrderResponseDTO>();
        return orderResponseDTO;
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var orders = await _orderRepository.GetOrdersByUserIdAsync(userId, cancellationToken);

        var ordersResponseDTO = orders.Adapt<IEnumerable<OrderResponseDTO>>();
        return ordersResponseDTO;
    }

    public async Task<OrderResponseDTO> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
        {
            throw new EntityNotFoundException(nameof(Order), orderId);
        }

        var orderResponseDTO = order.Adapt<OrderResponseDTO>();
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

}
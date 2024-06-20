﻿using FluentValidation;
using MapsterMapper;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Entities.Validators;
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
    private readonly IValidator<OrderItemRequestDTO> _validator;
    public OrderItemService(ShopDbContext context, IMapper mapper, AbstractValidator<OrderItemRequestDTO> validator)
    {
        _orderItemRepository = new OrderItemRepository(context);
        _mapper = mapper;
        _validator = validator;
    }
    public async Task CreateOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(requestDTO, token);
        var orderItem = _mapper.Map<OrderItem>(requestDTO);
        if (orderItem == null)
            throw new MappingException($"Unable to create entity of type {nameof(OrderItem)}.");
        await _orderItemRepository.CreateAsync(orderItem);
    }

    public async Task DeleteOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(requestDTO, token);
        var orderItem = await _orderItemRepository.GetByIdAsync(requestDTO.Id);
        if (orderItem == null)
            throw new EntityNotFoundException(nameof(OrderItem), requestDTO.Id);
        await _orderItemRepository.DeleteAsync(orderItem, token);
    }

    public async Task<IEnumerable<OrderItemResponseDTO>> GetAllAsync(CancellationToken token = default)
    {
        var orderItemsCollection = await _orderItemRepository.GetAllAsync(token);
        if (orderItemsCollection == null)
            throw new NullReferenceException("Unable to get order items collection");
        return _mapper.Map<IEnumerable<OrderItemResponseDTO>>(orderItemsCollection);
    }

    public async Task<OrderItemResponseDTO> GetByIdAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(requestDTO, token);
        var orderItem = await _orderItemRepository.GetByIdAsync(requestDTO.Id, token);
        if (orderItem == null)
            throw new EntityNotFoundException(nameof(OrderItem), requestDTO.Id);
        return _mapper.Map<OrderItemResponseDTO>(orderItem);
    }


    public async Task UpdateOrderItemAsync(OrderItemRequestDTO requestDTO, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(requestDTO, token);
        var orderItem = await _orderItemRepository.GetByIdAsync(requestDTO.Id, token);
        if (orderItem == null)
            throw new EntityNotFoundException(nameof(OrderItem), requestDTO.Id);
        _mapper.Map(requestDTO, orderItem);
        await _orderItemRepository.UpdateAsync(orderItem, token);
    }
}
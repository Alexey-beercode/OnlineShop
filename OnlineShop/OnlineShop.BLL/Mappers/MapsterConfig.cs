using Mapster;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Helpers;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Mappers;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Order, OrderResponseDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OrderDate, src => src.OrderDate)
            .Map(dest => dest.User, src => src.User.Adapt<UserResponseDTO>())
            .Map(dest => dest.OrderItems, src => src.OrderItems.Adapt<List<OrderItemResponseDTO>>());

        TypeAdapterConfig<OrderItem, OrderItemResponseDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.Quantity, src => src.Quantity);
        TypeAdapterConfig<RegisterRequestDTO, User>.NewConfig();
        TypeAdapterConfig<User, UserResponseDTO>.NewConfig();
        TypeAdapterConfig<Category, CategoryResponseDTO>.NewConfig();
        TypeAdapterConfig<IEnumerable<Product>, IEnumerable<ProductResponseDTO>>.NewConfig();
        TypeAdapterConfig<Product, ProductResponseDTO>.NewConfig();

        TypeAdapterConfig<ProductUpdateRequestDTO, Product>.NewConfig()
            .Ignore(dest => dest.Id)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Description, src => src.Description);
    }
}

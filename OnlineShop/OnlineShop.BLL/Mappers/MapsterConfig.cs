using Mapster;
using OnlineShop.BLL.DTO.Request;
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
        TypeAdapterConfig<IEnumerable<Category>, CategoriesCollectionResponseDTO>.NewConfig();
        TypeAdapterConfig<Category, CategoryResponseDTO>.NewConfig();
        TypeAdapterConfig<IEnumerable<Product>, IEnumerable<ProductResponseDTO>>.NewConfig();
        TypeAdapterConfig<Product, ProductResponseDTO>.NewConfig();

    }
}

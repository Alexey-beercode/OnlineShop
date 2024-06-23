using Mapster;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.Helpers;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Mappers;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<RegisterRequestDTO, User>.NewConfig();
        TypeAdapterConfig<User, UserResponseDTO>.NewConfig();
    }
}
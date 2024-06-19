using Mapster;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.Helpers;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Mappers;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<string, Guid>.NewConfig()
            .MapWith(src => StringToGuidMapper.ToGuid(src));

        TypeAdapterConfig<Guid,string>.NewConfig()
            .MapWith(src => StringToGuidMapper.ToString(src));
        
        TypeAdapterConfig<RegisterRequestDTO, User>.NewConfig()
            .Map(dest => dest.PasswordHash, src => PasswordHelper.HashPassword(src.Password))
            .Map(dest => dest.IsDeleted, src => false);
    }
}
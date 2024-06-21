﻿using Mapster;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Validators;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<string, Guid>.NewConfig()
            .MapWith(src => StringToGuidMapper.ToGuid(src));
    }
}
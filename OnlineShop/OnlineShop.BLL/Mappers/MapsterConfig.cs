using Mapster;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Mappers
{
    internal class MapsterConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<OrderItemRequestDTO, OrderItem>
                .NewConfig()
                .IgnoreNullValues(true);
        }
    }
}

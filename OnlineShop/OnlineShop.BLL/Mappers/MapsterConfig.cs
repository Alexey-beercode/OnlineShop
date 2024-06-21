using Mapster;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Mappers
{
    public class MapsterConfig: IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<OrderItemRequestDTO, OrderItem>()
                .IgnoreNullValues(true)
                .RequireDestinationMemberSource(true);

            config
                .NewConfig<OrderItem, OrderItemResponseDTO>()
                .IgnoreNullValues(true)
                .RequireDestinationMemberSource(true)
                .TwoWays();

            config
                .NewConfig<Product, ProductResponseDTO>();
        }
    }
}

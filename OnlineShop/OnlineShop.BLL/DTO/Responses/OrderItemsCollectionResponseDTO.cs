using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.DTO.Responses
{
    public class OrderItemsCollectionResponseDTO
    {
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public OrderItemsCollectionResponseDTO()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}

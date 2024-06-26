using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.DTO.Request
{
    public class CreateOrderRequestDTO
    {
        public required UserRequestDTO User { get; set; }
        public ICollection<OrderItemRequestDTO> OrderItems { get; set; } = new List<OrderItemRequestDTO>();
    }
}

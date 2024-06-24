using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.DTO.Response
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public UserResponseDTO User { get; set; }
        public ICollection<OrderItemResponseDTO> OrderItems { get; set; } = new List<OrderItemResponseDTO>();
    }
}

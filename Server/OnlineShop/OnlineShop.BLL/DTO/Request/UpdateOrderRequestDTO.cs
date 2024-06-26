using OnlineShop.BLL.DTO.Request;

namespace OnlineShop.Controllers
{
    public class UpdateOrderRequestDTO
    {
        public Guid UserId { get; set; }
        public IEnumerable<OrderItemRequestDTO> OrderItems { get; set; }
    }
}
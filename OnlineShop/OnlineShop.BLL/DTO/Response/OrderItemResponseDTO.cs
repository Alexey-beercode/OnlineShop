namespace OnlineShop.BLL.DTO.Response
{
    public class OrderItemResponseDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
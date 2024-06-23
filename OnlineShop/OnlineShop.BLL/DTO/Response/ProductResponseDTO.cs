using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.DTO.Responses;

public class ProductResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; } 
    public string Description { get; set; }
}
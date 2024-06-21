using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.DTO.Responses;

public class CategoriesCollectionResponseDTO
{
    public IEnumerable<Category> Categories { get; set; }
}
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.DTO.Response;

public class CategoriesCollectionResponseDTO
{
    public IEnumerable<Category> Categories { get; set; }
}
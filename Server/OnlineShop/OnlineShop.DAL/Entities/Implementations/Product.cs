using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class Product:IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    
}
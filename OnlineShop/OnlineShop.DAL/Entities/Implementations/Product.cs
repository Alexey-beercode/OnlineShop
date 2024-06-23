using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class Product:IEntity
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}
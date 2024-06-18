using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class OrderItem:IEntity
{
    public Guid Id { get; set; }
}
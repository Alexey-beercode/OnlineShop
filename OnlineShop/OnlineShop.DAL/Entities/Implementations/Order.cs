using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class Order:IEntity
{
    public Guid Id { get; set; }
}
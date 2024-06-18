using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class Category:IEntity
{
    public Guid Id { get; set; }
}
using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class User:IEntity
{
    public Guid Id { get; set; }
}
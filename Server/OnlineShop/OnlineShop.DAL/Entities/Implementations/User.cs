using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class User : IEntity
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public bool IsDeleted { get; set; }
}
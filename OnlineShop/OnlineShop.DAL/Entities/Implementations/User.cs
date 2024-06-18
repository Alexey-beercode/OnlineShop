using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class User : IEntity
{
    public Guid Id { get; set; }
    
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public required bool IsDeleted { get; set; }
}
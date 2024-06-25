using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class Order : IEntity
{
    public Guid Id { get; set; }

    public required DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public required ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public bool IsDeleted { get; set; }
    public bool IsCancelled { get; set; }

}
using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class OrderItem : IEntity
{
    public Guid Id { get; set; }
    public required Guid OrderId { get; set; }
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }

    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;

    public bool IsDeleted { get; set; }
}

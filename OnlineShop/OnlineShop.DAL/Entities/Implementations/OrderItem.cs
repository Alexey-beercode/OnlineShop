using OnlineShop.DAL.Entities.Interfaces;

namespace OnlineShop.DAL.Entities.Implementations;

public class OrderItem : IEntity
{
    public Guid Id { get; set; }
    public required int OrderId { get; set; }
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }

    public required Order Order { get; set; }
    public required Product Product { get; set; }
}

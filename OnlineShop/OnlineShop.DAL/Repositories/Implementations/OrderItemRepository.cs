using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Exceptions;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;
using System.Collections.Immutable;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderItemRepository : IBaseRepository<OrderItem>
{
    public ShopDbContext _context;

    public OrderItemRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
         return await _context.OrderItems.SingleAsync(oi => oi.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.OrderItems.ToListAsync(cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;
using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderItemRepository : IBaseRepository<OrderItem>
{
    private readonly ShopDbContext _context;

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

    public async Task CreateAsync(OrderItem entity, CancellationToken cancellationToken = default)
    {
        _context.OrderItems.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(OrderItem entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _context.OrderItems.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(OrderItem entity, CancellationToken cancellationToken = default)
    {
        _context.OrderItems.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
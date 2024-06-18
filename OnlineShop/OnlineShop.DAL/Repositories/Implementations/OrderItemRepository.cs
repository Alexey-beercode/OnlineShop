using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Exceptions;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;
using System.Collections.Immutable;

namespace OnlineShop.DAL.Repositories.Implementations;

public class OrderItemRepository:IBaseRepository<OrderItem>
{
    public ShopDbContext _context;

    public OrderItemRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItem> GetById(Guid id)
    {
        var result = await _context.OrderItems.SingleOrDefaultAsync(oi => oi.Id == id);
        return result ?? throw new EntityNotFoundException(nameof(OrderItem), id);
    }

    public async Task<IEnumerable<OrderItem>> GetAll()
    {
        var result = await _context.OrderItems.ToListAsync();
        return result ?? throw new RepositoryException("Cant find OrderItems table");
    }
}
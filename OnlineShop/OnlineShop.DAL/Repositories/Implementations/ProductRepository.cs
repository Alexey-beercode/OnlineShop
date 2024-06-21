using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class ProductRepository:IBaseRepository<Product>
{
    private readonly ShopDbContext _dbContext;

    public ProductRepository(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _dbContext.Products.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Product>()
            .Include(p => p.Category)
            .Where(p => !p.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    { 
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        product.IsDeleted = true;
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.Where(product => !product.IsDeleted && product.Category.Id == categoryId).ToListAsync();
    }
}
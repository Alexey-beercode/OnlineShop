using System.Net;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly ShopDbContext _dbContext;

    public CategoryRepository(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.Where(a => !a.IsDeleted).ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Category> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(a => !a.IsDeleted && a.Name==name,cancellationToken);
    }

    public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
    {
        category.IsDeleted = true;
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
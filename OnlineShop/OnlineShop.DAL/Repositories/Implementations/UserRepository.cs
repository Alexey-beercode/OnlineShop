using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly ShopDbContext _dbContext;

    public UserRepository(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FindAsync(id, cancellationToken);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _dbContext.Users.Where(u => !u.IsDeleted).ToListAsync(cancellationToken);
        return users;
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        user.IsDeleted = true;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
        return user;
    }
}
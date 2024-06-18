using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Infrastructure;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class UserRepository(ShopDbContext dbContext) : IUserRepository
{
    public async Task<User> GetById(Guid id)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id.Equals(id));
        return user; //TODO: Add error return after merge 
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await dbContext.Users.Where(u=> !u.IsDeleted).ToListAsync();
        return users; //TODO: Add error return after merge 
    }

    public async Task CreateAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        user.IsDeleted = true;

        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByLoginAsync(string login)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Login.Equals(login));
        return user;
    }
}
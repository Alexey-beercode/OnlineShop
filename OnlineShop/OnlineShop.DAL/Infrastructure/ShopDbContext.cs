using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Infrastructure
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories = null!;
        public DbSet<User> Users = null!;
        public DbSet<Order> Orders = null!;
        public DbSet<OrderItem> OrderItems = null!;
        public DbSet<Product> Products = null!;

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set up your entity configs
            base.OnModelCreating(modelBuilder);
        }
    }
}

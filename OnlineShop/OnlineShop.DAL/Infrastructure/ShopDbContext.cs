using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Infrastructure.Configurations;

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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set up your entity configs
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}

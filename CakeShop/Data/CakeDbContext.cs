using CakeShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Data
{
    public class CakeDbContext : DbContext
    {

        public CakeDbContext(DbContextOptions<CakeDbContext> options) : base(options)
        {

        }

        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Category> Catgoryes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

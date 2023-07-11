using Microsoft.EntityFrameworkCore;
using OrganicShop.Models;

namespace OrganicShop.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<AttributesPrices> AttributesPrices { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<TransactStatus> TransactStatus { get; set; }

    }
}

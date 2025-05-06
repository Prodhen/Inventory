using System;
using System.Reflection;
using API.Models;
using API.Models.Seed;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess;

public class InventoryDbContext:DbContext
{
    public InventoryDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Product> Products{ get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }

    public DbSet<SaleOrder> SaleOrders { get; set; }
     public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        UserSeeder.Seed(modelBuilder);
        ProductSeeder.Seed(modelBuilder);
    }

}

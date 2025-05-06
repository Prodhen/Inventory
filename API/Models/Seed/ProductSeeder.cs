using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Seed;

public static class ProductSeeder
{
     public static void Seed(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Mango",
                    SkuCode = "MG-001",
                    Price =18,     
                    StockQuantity = 200,
                    Description = "Good",
                    ImagePath = null,
                    IsDeleted = false,
                    CreatedBy = 1,       
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Apple",
                    SkuCode = "AP-002",
                    Price = 20,      
                    StockQuantity = 150,
                    Description = "Apples from china",
                    ImagePath = null,
                    IsDeleted = false,
                    CreatedBy = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Banana",
                    SkuCode = "BN-003",
                    Price = 10,       
                    StockQuantity = 300,
                    Description = "Organic  bananas",
                    ImagePath = null,
                    IsDeleted = false,
                    CreatedBy = 1,
                    CreatedAt = DateTime.UtcNow
                }
               
            );
        }
    }



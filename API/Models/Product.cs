using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models;

public class Product
{

    public int Id { get; set; }

    public required string  ProductName { get; set; }


    public string? SkuCode { get; set; }


    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? Description { get; set; }
    public string? ImagePath {get;set;}


    public bool IsDeleted { get; set; } = false;

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<SaleItem>? SaleItems { get; set; }

    public  User CreatedByUser { get; set; }
    public User? UpdatedByUser { get; set; }

}
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.ProductName)
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(p => p.SkuCode)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.StockQuantity)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("text");

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.CreatedBy)
            .IsRequired();  builder.HasOne(p => p.CreatedByUser)
            .WithMany()
            .HasForeignKey(p => p.CreatedBy);

        builder.HasOne(p => p.UpdatedByUser)
            .WithMany()
            .HasForeignKey(p => p.UpdatedBy);


    }
}

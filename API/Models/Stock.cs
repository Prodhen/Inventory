using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models;

public class Stock
{
     public int Id { get; set; }
    public int ProductId { get; set; }
    public required string Type { get; set; } 
    public required string  Reference {get; set; }
    public int Quantity { get; set; }

    public string? Remarks { get; set; }


    public bool IsDeleted { get; set; } = false;

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }


    public  User CreatedByUser { get; set; }
    public User? UpdatedByUser { get; set; }
    public Product Product { get; set; }

}
public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
   
        builder.ToTable("Stocks");

 
        builder.Property(s => s.Type)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(s => s.Quantity)
            .IsRequired();

        builder.Property(s => s.Remarks)
            .HasMaxLength(500)
            .HasColumnType("varchar(500)");

        builder.Property(s => s.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(s => s.CreatedAt)
            .IsRequired();

        builder.Property(s => s.CreatedBy)
            .IsRequired();

    
        builder.HasOne(s => s.Product)
            .WithMany()
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.CreatedByUser)
            .WithMany()
            .HasForeignKey(s => s.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.UpdatedByUser)
            .WithMany()
            .HasForeignKey(s => s.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

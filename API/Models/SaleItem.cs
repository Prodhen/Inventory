using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models;

public class SaleItem
{
    public int Id { get; set; } // Auto-increment
    public int SaleOrderId { get; set; } // Foreign key to SaleOrder
    public SaleOrder SaleOrder { get; set; } // Navigation property to SaleOrder

    public int ProductId { get; set; } // Foreign key to Product
    public Product Product { get; set; } // Navigation property to Product

    public int QuantitySold { get; set; } // Quantity sold of the product
    public decimal TotalPrice { get; set; } // Price * QuantitySold


    public bool IsDeleted { get; set; } = false;

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public  User CreatedByUser { get; set; }
    public User? UpdatedByUser { get; set; }

    public void Validate()
    {
        if (QuantitySold <= 0)
            throw new ArgumentException("Quantity sold must be greater than 0.");
    }


}

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.HasKey(si => si.Id); 

      
        builder.HasOne(si => si.SaleOrder)
            .WithMany(so => so.SaleItems)
            .HasForeignKey(si => si.SaleOrderId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(si => si.Product)
            .WithMany(p => p.SaleItems)
            .HasForeignKey(si => si.ProductId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Property(si => si.QuantitySold)
            .IsRequired(); 

        builder.Property(si => si.TotalPrice)
            .HasColumnType("decimal(18,2)") 
            .IsRequired();

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);


        builder.Property(si => si.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");




        builder.Property(si => si.UpdatedAt)
            .IsRequired(false)
            .HasDefaultValueSql("NULL");
       builder.Property(si => si.CreatedBy)
            .IsRequired();  builder.HasOne(si => si.CreatedByUser)
            .WithMany()
            .HasForeignKey(si => si.CreatedBy);

        builder.HasOne(si => si.UpdatedByUser)
            .WithMany()
            .HasForeignKey(si => si.UpdatedBy);
    }
}


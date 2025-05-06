using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models;

public class SaleOrder
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.UtcNow; 
    public string Code {get;set;}

    public bool IsDeleted { get; set; } = false;

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public  User CreatedByUser { get; set; }
    public User? UpdatedByUser { get; set; }

    
    public ICollection<SaleItem> SaleItems { get; set; }


}

public class SaleOrderConfiguration : IEntityTypeConfiguration<SaleOrder>
{
    public void Configure(EntityTypeBuilder<SaleOrder> builder)
    {
        builder.HasKey(so => so.Id);

        builder.Property(so => so.SaleDate)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()"); 

   
        builder.HasMany(so => so.SaleItems)
            .WithOne(si => si.SaleOrder)
            .HasForeignKey(si => si.SaleOrderId)
            .OnDelete(DeleteBehavior.Cascade); 

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


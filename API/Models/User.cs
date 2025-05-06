using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models;

public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required byte[] PassWordHash { get; set; }
    public required byte[] PassWordSalt { get; set; }
    public int? RoleId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool Status { get; set; } = true;
    public string? ImagePath { get; set; }
    
    public int? CreatedBy { get; set; } 
    public int? UpdatedBy { get; set; }  

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("CreatedBy")]
    public virtual User? CreatedByUser { get; set; }
    
    [ForeignKey("UpdatedBy")]
    public virtual User? UpdatedByUser { get; set; }
    

}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.PassWordHash)
               .IsRequired();

        builder.Property(u => u.PassWordSalt)
               .IsRequired();

        builder.Property(u => u.IsDeleted)
               .HasDefaultValue(false);

        builder.Property(u => u.Status)
               .HasDefaultValue(true);

        builder.Property(u => u.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(u => u.ImagePath)
               .HasMaxLength(255);

       builder.HasOne(u => u.CreatedByUser)
               .WithMany()
               .HasForeignKey(u => u.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

        builder.HasOne(u => u.UpdatedByUser)
               .WithMany()
               .HasForeignKey(u => u.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);



    }
}
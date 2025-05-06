using System;
using API.Helper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Seed;

public static class UserSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var (adminHash, adminSalt) = PasswordHelper.CreateHash("Admin@123");
        var (managerHash, managerSalt) = PasswordHelper.CreateHash("Manager@123");
        var (userHash, userSalt) = PasswordHelper.CreateHash("User@123");

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "admin",
                PassWordHash = adminHash,
                PassWordSalt = adminSalt,
                CreatedAt = DateTime.UtcNow,
                Status = true
            },
            new User
            {
                Id = 2,
                UserName = "manager",
                PassWordHash = managerHash,
                PassWordSalt = managerSalt,
                CreatedBy = 1,
                CreatedAt = DateTime.UtcNow,
                Status = true
            },
            new User
            {
                Id = 3,
                UserName = "user",
                PassWordHash = userHash,
                PassWordSalt = userSalt,
                CreatedBy = 1,
                CreatedAt = DateTime.UtcNow,
                Status = true
            }
        );
    }

}

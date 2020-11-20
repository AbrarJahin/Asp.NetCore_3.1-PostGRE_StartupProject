using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class UserSeeder
    {
        internal static ICollection<Guid> Execute(ModelBuilder builder)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            List<Guid> adminUserIdList = new List<Guid>();
            Guid userId = Guid.NewGuid();
            //Seeding the User to AspNetUsers table
            builder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    UserName = "abrar",
                    NormalizedUserName = "abrar".Normalize().ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "abrar@jahin.com"),
                    Email = "abrar@jahin.com",
                    NormalizedEmail = "abrar@jahin.com".Normalize().ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = DateTime.Now.Ticks.ToString()+"_"+Guid.NewGuid()
                }
            );
            adminUserIdList.Add(userId);
            return adminUserIdList;
        }
    }
}

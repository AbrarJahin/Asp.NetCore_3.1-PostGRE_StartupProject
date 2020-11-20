using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class UserSeeder
    {
        internal static void Execute(ModelBuilder builder)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            //Seeding the User to AspNetUsers table
            builder.Entity<User>().HasData(
                new User
                {
                    UserName = "abrar",
                    NormalizedUserName = "abrar".Normalize().ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "abrar@jahin.com"),
                    Email = "abrar@jahin.com",
                    NormalizedEmail = "abrar@jahin.com".Normalize().ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = DateTime.Now.Ticks.ToString()+"_"+Guid.NewGuid()
                }
            );
        }
    }
}

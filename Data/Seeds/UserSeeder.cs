using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class UserSeeder
    {
        internal static void Execute(ModelBuilder builder)
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            //Seeding the User to AspNetUsers table
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    UserName = "abrar",
                    NormalizedUserName = "abrar".Normalize().ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "abrar@jahin.com"),
                    Email = "abrar@jahin.com",
                    NormalizedEmail = "abrar@jahin.com".Normalize().ToUpper(),
                    EmailConfirmed = true
                }
            );
        }
    }
}

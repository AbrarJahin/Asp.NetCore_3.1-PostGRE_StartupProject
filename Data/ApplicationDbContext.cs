using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using StartupProject_Asp.NetCore_PostGRE.Data.Seeds;

namespace StartupProject_Asp.NetCore_PostGRE.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly IWebHostEnvironment Environment;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env)
            : base(options)
        {
            Environment = env;
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Rename default Identity Table Names
            builder.HasDefaultSchema("public");

            builder.Entity<RoleClaim>(builder =>
            {
                builder.HasOne(roleClaim => roleClaim.Role).WithMany(role => role.Claims).HasForeignKey(roleClaim => roleClaim.RoleId);
            });
            
            builder.Entity<UserClaim>(builder =>
            {
                builder.HasOne(userClaim => userClaim.User).WithMany(user => user.Claims).HasForeignKey(userClaim => userClaim.UserId);
            });
            builder.Entity<UserLogin>(builder =>
            {
                builder.HasOne(userLogin => userLogin.User).WithMany(user => user.Logins).HasForeignKey(userLogin => userLogin.UserId);
            });
            builder.Entity<UserRole>(builder =>
            {
                builder.HasOne(userRole => userRole.Role).WithMany(role => role.Users).HasForeignKey(userRole => userRole.RoleId);
                builder.HasOne(userRole => userRole.User).WithMany(user => user.Roles).HasForeignKey(userRole => userRole.UserId);
            });
            builder.Entity<UserToken>(builder =>
            {
                builder.HasOne(userToken => userToken.User).WithMany(user => user.UserTokens).HasForeignKey(userToken => userToken.UserId);
            });
            #endregion

            #region Data Seeding
            if (Environment.IsDevelopment())
            {
                using (SeedController seeder = new SeedController(builder))
                {
                    seeder.Execute();
                }
            }
            #endregion
        }
    }
}

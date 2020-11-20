using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using StartupProject_Asp.NetCore_PostGRE.Data.Seeds;
using System;

namespace StartupProject_Asp.NetCore_PostGRE.Data
{
    //public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private string IdentitySchemaName = "Identity";
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
                //builder.HasOne(roleClaim => roleClaim.Role).WithMany(role => role.Claims).HasForeignKey(roleClaim => roleClaim.RoleId);
                builder.ToTable("RoleClaim", schema: IdentitySchemaName);
            });
            builder.Entity<Role>(builder =>
            {
                builder.ToTable("Role", schema: IdentitySchemaName);
            });
            builder.Entity<UserClaim>(builder =>
            {
                //builder.HasOne(userClaim => userClaim.User).WithMany(user => user.Claims).HasForeignKey(userClaim => userClaim.UserId);
                builder.ToTable("UserClaim", schema: IdentitySchemaName);
            });
            builder.Entity<UserLogin>(builder =>
            {
                //builder.HasOne(userLogin => userLogin.User).WithMany(user => user.Logins).HasForeignKey(userLogin => userLogin.UserId);
                builder.ToTable("UserLogin", schema: IdentitySchemaName);
            });
            builder.Entity<User>(builder =>
            {
                builder.ToTable("User", schema: IdentitySchemaName);
            });
            builder.Entity<UserRole>(builder =>
            {
                //builder.HasOne(userRole => userRole.Role).WithMany(role => role.Users).HasForeignKey(userRole => userRole.RoleId);
                //builder.HasOne(userRole => userRole.User).WithMany(user => user.Roles).HasForeignKey(userRole => userRole.UserId);
                builder.ToTable("UserRole", schema: IdentitySchemaName);
            });
            builder.Entity<UserToken>(builder =>
            {
                //builder.HasOne(userToken => userToken.User).WithMany(user => user.UserTokens).HasForeignKey(userToken => userToken.UserId);
                builder.ToTable("UserToken", schema: IdentitySchemaName);
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

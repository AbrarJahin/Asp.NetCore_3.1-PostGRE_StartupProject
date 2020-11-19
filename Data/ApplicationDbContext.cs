using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StartupProject_Asp.NetCore_PostGRE.Data.Models;
using StartupProject_Asp.NetCore_PostGRE.Data.Seeds;

namespace StartupProject_Asp.NetCore_PostGRE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
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

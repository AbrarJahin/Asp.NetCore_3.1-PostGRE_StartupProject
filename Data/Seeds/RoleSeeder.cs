using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class RoleSeeder
    {
        internal static void Execute(ModelBuilder builder, ICollection<Guid> superAdminUserIdList)
        {
            IList<Role> roleList = new List<Role>();
            IList<UserRole> userRoleList = new List<UserRole>();
            foreach (Guid superAdminId in superAdminUserIdList)
            {
                foreach (object name in Enum.GetValues(typeof(ERoles)))
                {
                    string description = ((ERoles)name).Description();
                    Guid roleId = Guid.NewGuid();
                    roleList.Add(new Role
                    {
                        Id = roleId,
                        Name = name.ToString(),
                        NormalizedName = name.ToString().Normalize().ToUpper(),
                        Description = description
                    });
                    userRoleList.Add(new UserRole
                    {
                        RoleId = roleId,
                        UserId = superAdminId,
                        ReasonForAdding = "Migration"
                    });
                }
            }
            
            builder.Entity<Role>().HasData(roleList);
            builder.Entity<UserRole>().HasData(userRoleList);
        }
    }
}

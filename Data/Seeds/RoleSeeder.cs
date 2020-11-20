using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class RoleSeeder
    {
        internal static void Execute(ModelBuilder builder)
        {
            IList<Role> roleList = new List<Role>();
            foreach (object name in Enum.GetValues(typeof(ERoles)))
            {
                string description = ((ERoles)name).Description();
                roleList.Add(new Role
                {
                    Name = name.ToString(),
                    NormalizedName = name.ToString().Normalize().ToUpper(),
                    Description = description
                });
            }
            builder.Entity<Role>().HasData(roleList);
        }
    }
}

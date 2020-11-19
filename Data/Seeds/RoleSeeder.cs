using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using System;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class RoleSeeder
    {
        internal static void Execute(ModelBuilder builder)
        {
            IList<IdentityRole> roleList = new List<IdentityRole>();
            foreach (object name in Enum.GetValues(typeof(ERoles)))
            {
                string description = ((ERoles)name).Description();
                roleList.Add(new IdentityRole
                {
                    Name = name.ToString()
                });
                
            }
            builder.Entity<IdentityRole>().HasData(roleList);
        }
    }
}

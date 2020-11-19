using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using System;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class RoleSeeder
    {
        internal static void Execute(ModelBuilder builder)
        {
            foreach (object name in Enum.GetValues(typeof(ERoles)))
            {
                string description = ((ERoles)name).Description();
                string nameVal = name.ToString();
                description = nameVal;
            }
        }
    }
}

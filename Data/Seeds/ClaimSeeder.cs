using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class ClaimSeeder
    {
        internal static void Execute(ModelBuilder builder, ICollection<Guid> superAdminUserIdList)
        {
            int itemCount = -1;
            IList<UserClaim> userClaimList = new List<UserClaim>();
            IList<RoleClaim> roleClaimList = new List<RoleClaim>();
            foreach (Guid superAdminId in superAdminUserIdList)
            {
                foreach (object name in Enum.GetValues(typeof(EClaim)))
                {
                    string description = ((EClaim)name).Description();
                    userClaimList.Add(new UserClaim {
                        Id = itemCount--,
                        UserId = superAdminId,
                        ClaimType = name.ToString(),
                        ClaimValue = description
                    });
                }
            }
            builder.Entity<UserClaim>().HasData(userClaimList);
        }
    }
}
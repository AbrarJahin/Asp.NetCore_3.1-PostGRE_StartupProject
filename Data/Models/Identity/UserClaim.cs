using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserClaims", Schema = "Identity")]
    public class UserClaim : IdentityUserClaim<Guid>
    {
        //public virtual User User { get; set; }
    }
}
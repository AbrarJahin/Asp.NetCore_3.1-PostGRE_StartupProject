using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserTokens", Schema = "Identity")]
    public class UserToken : IdentityUserToken<Guid>
    {
        //[Column("UserId")]
        //public virtual User User { get; set; }
    }
}
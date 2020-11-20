using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserLogins", Schema = "Identity")]
    public class UserLogin : IdentityUserLogin<Guid>
    {
        //[Column("UserId")]
        //public virtual User User { get; set; }
        public string LoginIp { get; set; }
    }
}
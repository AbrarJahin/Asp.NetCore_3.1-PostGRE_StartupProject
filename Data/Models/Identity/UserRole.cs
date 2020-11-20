using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserRoles", Schema = "Identity")]
    public class UserRole : IdentityUserRole<Guid>
    {
        //public virtual User User { get; set; }
        //public virtual Role Role { get; set; }
    }
}

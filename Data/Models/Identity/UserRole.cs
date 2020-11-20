using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserRoles", Schema = "Identity")]
    public class UserRole : IdentityUserRole<Guid>
    {
        public string ReasonForAdding { get; set; }
    }
}

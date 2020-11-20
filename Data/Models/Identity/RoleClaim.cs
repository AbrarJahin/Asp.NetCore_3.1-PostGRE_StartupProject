using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("RoleClaims", Schema = "Identity")]
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
    }
}

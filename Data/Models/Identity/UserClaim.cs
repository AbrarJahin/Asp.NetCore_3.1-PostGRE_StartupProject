using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserClaims", Schema = "Identity")]
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
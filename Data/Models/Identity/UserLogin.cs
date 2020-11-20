using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserLogins", Schema = "Identity")]
    public class UserLogin : IdentityUserLogin<string>
    {
        public virtual User User { get; set; }
    }
}
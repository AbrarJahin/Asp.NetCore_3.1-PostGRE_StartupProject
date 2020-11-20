using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("UserTokens", Schema = "Identity")]
    public class UserToken : IdentityUserToken<string>
    {
        public virtual User User { get; set; }
    }
}
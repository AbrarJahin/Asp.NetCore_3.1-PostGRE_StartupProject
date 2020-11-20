using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("Roles", Schema = "Identity")]
    public class Role: IdentityRole
    {
        public Role() : base()
        {

        }
        public Role(string roleName) : this()
        {
            Name = roleName;
        }

        public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}

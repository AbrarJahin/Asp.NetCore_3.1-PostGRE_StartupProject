using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity
{
    [Table("Roles", Schema = "Identity")]
    public class Role: IdentityRole<Guid>
    {
        public override Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}

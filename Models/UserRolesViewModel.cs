using System;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Models
{
    public class UserRolesViewModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}

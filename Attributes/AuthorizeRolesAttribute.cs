using Microsoft.AspNetCore.Authorization;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StartupProject_Asp.NetCore_PostGRE.Attributes
{
    internal class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params ERole[] allowedRoles)
        {
            IEnumerable<string> allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(ERole), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
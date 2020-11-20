using Microsoft.AspNetCore.Authorization;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StartupProject_Asp.NetCore_PostGRE.Attributes
{
    internal class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params ERoles[] allowedRoles)
        {
            IEnumerable<string> allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(ERoles), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
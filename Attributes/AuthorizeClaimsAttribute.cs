using Microsoft.AspNetCore.Authorization;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;

namespace StartupProject_Asp.NetCore_PostGRE.Attributes
{
    public class AuthorizeClaimsAttribute : AuthorizeAttribute
    {
        public AuthorizeClaimsAttribute(params EClaim[] allowedRoles)
        {
            // Need to implement
        }
    }
}

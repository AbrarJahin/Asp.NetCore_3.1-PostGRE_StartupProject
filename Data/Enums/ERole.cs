using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum ERole
    {
        [Display(Name = "Can't be assigned by system")]
        [Description("Super Admin")]
        SuperAdmin = 0,
        [Description("Admin")]
        Admin,
        [Description("Auditor")]
        Auditor,
        [Description("Team Member")]
        TeamMember,
        [Description("Basic Member")]
        BasicMember
    }
}

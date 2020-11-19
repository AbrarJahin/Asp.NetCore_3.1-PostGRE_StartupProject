using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum ERoles
    {
        [Display(Name = "By Alpha")]
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

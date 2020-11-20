using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum EClaim
    {
        [Display(Name = "Role Read")]
        [Description("Read Role")]
        RoleRead = 0,
        [Description("Write Role")]
        RoleWrite,
        [Description("Update Role")]
        RoleUpdate,
        [Description("Delete Role")]
        RoleDelete
    }
}

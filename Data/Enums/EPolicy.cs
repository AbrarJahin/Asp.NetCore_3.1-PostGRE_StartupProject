using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum EPolicy
    {
        [Display(Name = "Role Read")]
        [Description("Role-Read")]
        RoleRead = 0,
        [Description("Role-Write")]
        RoleWrite,
        [Description("Role-Update")]
        RoleUpdate,
        [Description("Role-Delete")]
        RoleDelete
    }
}

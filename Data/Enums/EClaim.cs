using System.ComponentModel;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum EClaim
    {
        //[Display(Name = "Role-Claim Policy")]
        [Description("SuperAdmin.All")]
        SuperAdmin_All = 0,
        [Description("Role.Create")]
        Role_Create,
        [Description("Role.Read")]
        Role_Read,
        [Description("Role.Update")]
        Role_Update,
        [Description("Role.Delete")]
        Role_Delete,
        [Description("Claim.Create")]
        Claim_Create,
        [Description("Term.Create")]
        Term_Create,
        [Description("Term.Read")]
        Term_Read,
        [Description("Term.Update")]
        Term_Update,
        [Description("Term.Delete")]
        Term_Delete,
        [Description("Data.Verify")]
        Data_Verify,
        [Description("Export.All_Data")]
        Export_All_Data,
        [Description("Export.Domain_Data")]
        Export_Domain_Data,
        [Description("Synonym.Create")]
        Synonym_Create,
        [Description("Synonym.Read")]
        Synonym_Read,
        [Description("Synonym.Update")]
        Synonym_Update,
        [Description("Synonym.Delete")]
        Synonym_Delete,
        [Description("Connection.Create")]
        Connection_Create,
        [Description("Connection.Read")]
        Connection_Read,
        [Description("Connection.Update")]
        Connection_Update,
        [Description("Connection.Delete")]
        Connection_Delete
    }
}

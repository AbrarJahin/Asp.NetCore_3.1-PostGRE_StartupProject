using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Validators
{
    internal class CheckboxMustBeCheckedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
}
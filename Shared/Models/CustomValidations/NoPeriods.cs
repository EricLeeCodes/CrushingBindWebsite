using System.ComponentModel.DataAnnotations;

namespace Shared.Models.CustomValidations
{

    //sealed so it can be inherited from.
    public sealed class NoPeriods : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string input = value.ToString();

            bool noPeriods = input.Contains('.') == false;

            return noPeriods;
        }
    }
}

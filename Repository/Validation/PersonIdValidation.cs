using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Repository.Validation
{
    public class PersonIdValidation : ValidationAttribute
    {
        /// <summary>
        /// This validation validates the personId that is submitted as a object into the function   
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>   Null if the regEx matches the value
        ///             ErrorMessage if it does not match
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {            
            string _personId = Convert.ToString(value);            
            if (!(Regex.IsMatch(_personId, "^[1-2][0-9]{3}[0-1][1-9][0-3][1-9][-][0-9]{4}$")))
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            else
            {
                return null;
            }
        }
    }
}

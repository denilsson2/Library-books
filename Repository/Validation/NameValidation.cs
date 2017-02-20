using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Repository.Validation
{
    public class NameValidation : ValidationAttribute
    {
        /// <summary>
        /// This validation validates the Name that is submitted as a object into the function   
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>   Null if the regEx matches the value
        ///             ErrorMessage if it does not match
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string _namn = Convert.ToString(value);
            if (!(Regex.IsMatch(_namn, "^[a-zA-ZåäöÅÄÖ-]{2,20}$")))
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            return null;  
        }
    }
}

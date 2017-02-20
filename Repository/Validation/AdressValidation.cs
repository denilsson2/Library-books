using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Repository.Validation
{
    public class AdressValidation : ValidationAttribute
    {
        /// <summary>
        /// This validation validates the Adress that is submitted as a object into the function   
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>   Null if the regEx matches the value
        ///             ErrorMessage if it does not match
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string _adress = Convert.ToString(value);
            if (!(Regex.IsMatch(_adress, "^[\\wåäöÅÄÖ\\s-\\.;:]+$")))
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            return null;            
        }    
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Repository.Validation
{
    public class EmailValidation : ValidationAttribute
    {
        /// <summary>
        /// This validation validates the email that is submitted as a object into the function   
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>   Null if the regEx matches the value
        ///             ErrorMessage if it does not match
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string _email = Convert.ToString(value);
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (!( re.IsMatch(_email)))
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            return null;
        }
    }
}

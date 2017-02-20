using System.Text.RegularExpressions;

namespace Repository.Validation
{
    /// <summary>
    /// Validates if the Password submitet is a suitable password. 
    /// </summary>
    /// <Returns>
    /// True
    /// False
    public class PasswordValidaton
    {
        public static string ErrorMessage = "Lösenord måste vara mellan 5-15 tecken långt och innehålla minst en siffra och en versal.";

        public static bool IsValid(string password)
        {
            if (password != null && Regex.IsMatch(password, "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{5,15}$"))
                return true;
            
            return false;            
        }    
    }
}

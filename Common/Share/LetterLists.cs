using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Share
{
    /// <summary>
    /// Different type of lists 
    /// </summary>
    public class LetterLists
    {
        public static List<string> LetterList = new List<string>(
            new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö" }
            );
        
        public static List<string> LetterListWithNum = new List<string>(
            new string[] { "123", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö" }
            );

        public static List<string> NumbList = new List<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
    }
}

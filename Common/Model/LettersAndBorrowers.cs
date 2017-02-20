using Repository.EntityModel;
using System.Collections.Generic;

namespace Common.Model
{
    /// <summary>
    /// Used when list borrowera under a letter
    /// </summary>
    public class LettersAndBorrowers : Base.LettersAndModel<borrower>
    {
        public LettersAndBorrowers(List<string> letters, List<borrower> borrowers) : base(letters, borrowers)
        {}
    }
}

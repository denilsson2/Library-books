using System.Collections.Generic;
using Repository.EntityModel;

namespace Common.Model
{
    /// <summary>
    /// Used when list Books under a letter
    /// </summary>
    public class LettersAndBooks : Base.LettersAndModel<book>
    {
        public LettersAndBooks(List<string> letters, List<book> books) : base(letters, books) 
        {}
    }
}

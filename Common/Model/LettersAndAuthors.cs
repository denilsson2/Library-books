using Repository.EntityModel;
using System.Collections.Generic;

namespace Common.Model
{
    /// <summary>
    /// Used when list Authors under a letter
    /// </summary>
    public class LettersAndAuthors : Base.LettersAndModel<author>
    {
        public LettersAndAuthors(List<string> letters, List<author> authors) : base(letters, authors)
        {}
    }
}

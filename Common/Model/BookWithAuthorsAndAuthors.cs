using Common.Model.Base;
using Repository.EntityModel;
using System.Collections.Generic;

namespace Common.Model
{    
    /// <summary>
    /// Used when adding an author to a book
    /// </summary>
    public class BookWithAuthorsAndAuthors : BaseModel
    {
        public book Book { get; set; }
        /// <summary>
        /// Lists all authors connected to book
        /// </summary>
        public List<author> BookAuthors { get; set; }
        /// <summary>
        /// Lists all authors in database to chose from
        /// </summary>
        public List<author> Authors { get; set; }
    }
}

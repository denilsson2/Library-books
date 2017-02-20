using Repository.EntityModel;
using System.Collections.Generic;

namespace Common.Model
{
    /// <summary>
    /// used when adding a book to an author
    /// </summary>
    public class AuthorWithBooksAndBooks
    {
        public author Author { get; set; }
        /// <summary>
        /// list with books connected to an author
        /// </summary>
        public List<book> AuthorBooks { get; set; }
        /// <summary>
        /// List with books from database
        /// </summary>
        public List<book> Books { get; set; }
    }
}

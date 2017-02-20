using System.Collections.Generic;
using Repository.EntityModel;

namespace Common.Model
{
    /// <summary>
    /// Displays all books that an author been a part of
    /// </summary>
    public class AuthorWithBooks
    {
        public author Author { get; set; }
        public List<book> Books { get; set; }
    }
}
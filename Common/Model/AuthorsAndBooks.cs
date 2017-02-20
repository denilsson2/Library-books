using System.Collections.Generic;
using Repository.EntityModel;

namespace Common.Model
{
    /// <summary>
    /// Lists authors and books from public search
    /// </summary>
    public class AuthorsAndBooks
    {
        public List<author> Authors { get; set; }
        public List<book> Books { get; set; }
               
    }
}

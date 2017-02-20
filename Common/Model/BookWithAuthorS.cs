using System.Collections.Generic;
using Repository.EntityModel;

namespace Common.Model
{
    public class BookWithAuthors
    {
        public book Book { get; set; }
        public List<author> Authors { get; set; }
    }
}
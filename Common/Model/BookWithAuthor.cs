using Repository.EntityModel;

namespace Common.Model
{
    public class BookWithAuthor
    {
        public bookAuthor Book_Author { get; set; }
        public book Book { get; set; }
        public author Author { get; set; }
    }
}
using System.Collections.Generic;
using Repository.EntityModel;

namespace Common.Model
{
    /// <summary>
    /// Used when displaying a borrowed book
    /// </summary>
    public class BorrowedBookCopy
    {
        public book Book { get; set; }
        public List<author> Authors { get; set; }
        public borrow Borrow { get; set; }
        public category Category { get; set; }
        public int Fine { get; set; }
    }
}
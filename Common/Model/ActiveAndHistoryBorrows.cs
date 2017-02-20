using System.Collections.Generic;

namespace Common.Model
{
    /// <summary>
    /// Lists current loans and loans in the history
    /// </summary>
    public class ActiveAndHistoryBorrows
    {
        public List<BorrowedBookCopy> Active { get; set; }
        public List<BorrowedBookCopy> History { get; set; }
    }
}

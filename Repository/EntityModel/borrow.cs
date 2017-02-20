using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityModel
{
    public class borrow
    {
        public string Barcode { get; set; }
        public string PersonId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ToBeReturnedDate { get; set; }
        public string ReturnDate { get; set; }
    }
}

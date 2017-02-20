using Repository.EntityModel;
using Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class BorrowRepository : BaseRepository<borrow>
    {
        public static List<borrow> GetBorrowListByPersonId(string PersonId)
        {
            return dbGetList("SELECT * FROM Borrow WHERE PersonId = @PERSONID", new SqlParameter[] {
                new SqlParameter("@PERSONID", PersonId)
            });
        }

        public static List<borrow> GetActiveBorrowListByPersonId(string PersonId)
        {
            return dbGetList("SELECT * FROM BORROW WHERE PersonId = @PERSONID AND ReturnDate IS NULL;", new SqlParameter[] {
                new SqlParameter("@PERSONID", PersonId)
            });
        }
        
        public static List<borrow> GetHistoryBorrowListByPersonId(string PersonId)
        {
            return dbGetList("SELECT * FROM BORROW WHERE PersonId = @PERSONID AND ReturnDate IS NOT NULL;", new SqlParameter[] {
                new SqlParameter("@PERSONID", PersonId)
            });
        }

        public static List<borrow> GetBorrowListByISBN(string Isbn)
        {
            return dbGetList("SELECT * FROM BORROW AS B, COPY AS C WHERE B.Barcode = C.Barcode AND C.ISBN = @ISBN", new SqlParameter[] {
                new SqlParameter("@ISBN", Isbn)
            });
        }

        public static List<borrow> GetBorrowListByBarcode(string Barcode)
        {
            return dbGetList("SELECT * FROM BORROW WHERE Barcode = @BARCODE", new SqlParameter[] {
                new SqlParameter("@BARCODE", Barcode)
            });
        }

        public static void UpdateBorrowDates(string PersonId, string Barcode, DateTime ToBeReturnedDate )
        {
            dbPost("UPDATE BORROW SET BorrowDate = GetDate(), ToBeReturnedDate = @TOBERETURNEDDATE WHERE Barcode = @BARCODE AND PersonId = @PERSONID;", new SqlParameter[] {
                new SqlParameter("@TOBERETURNEDDATE", ToBeReturnedDate.ToString()),
                new SqlParameter("@BARCODE", Barcode),
                new SqlParameter("@PERSONID", PersonId)
            });
        }

        public static void RemoveBorrowsByPersonId(string PersonId)
        {
            dbPost("DELETE FROM Borrow WHERE PersonId = @PERSONID", new SqlParameter[] { 
                new SqlParameter("@PERSONID", PersonId)
            });
        }
    }
}

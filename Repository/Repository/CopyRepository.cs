using Repository.EntityModel;
using Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class CopyRepository : BaseRepository<copy>
    {
        static public copy GetCopyByBarcode(string Barcode){
            return dbGet("SELECT * FROM COPY WHERE Barcode = @BARCODE;", new SqlParameter[] {
                new SqlParameter("@BARCODE", Barcode)
            });
        }

        private static string getNextBarcode()
        {
            string _barcode = dbGet("SELECT CONVERT(BIGINT,MAX(BARCODE))+1 AS BARCODE FROM COPY;", null).Barcode;
            return (Convert.ToInt64(_barcode) + 1).ToString();
        }

        public static List<copy> GetCopiesByISBN(string ISBN)
        {
            return dbGetList("SELECT * FROM COPY WHERE ISBN = @ISBN", new SqlParameter[] {
                new SqlParameter("@ISBN", ISBN)
            });
        }

        public static void RemoveCopy(string Barcode)
        {
            dbPost("DELETE FROM COPY WHERE Barcode = @BARCODE", new SqlParameter[] {
                new SqlParameter("@BARCODE", Barcode)
            });
        }

        public static void CreateCopy(string isbn, string library)
        {
            dbPost("INSERT INTO COPY VALUES (@BARCODE, null, 1, @ISBN, @LIBRARY)", new SqlParameter[] {
                new SqlParameter("@BARCODE", getNextBarcode()),
                new SqlParameter("@ISBN", isbn),
                new SqlParameter("@LIBRARY", library)
            });
        }
    }
}

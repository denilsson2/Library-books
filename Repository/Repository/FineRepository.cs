using Repository.Repositories;
using Repository.Repository.Base;
using System;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class FineRepository
    {
        /// <summary>
        /// Calculating a borrower's fine
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static int GetFine(string barcode, string personId)
        {
            int _fine = 0;
            SqlIt sqlIt = new SqlIt(new SqlConnection(DataSource.getConnectionString("projectmanager")), "SELECT SUM(Penaltyperday * (DATEDIFF(DAY, ToBeReturnedDate,GETDATE()))) AS 'Avgift' FROM BORROWER, CATEGORY, BORROW, COPY WHERE BORROWER.CategoryId = CATEGORY.CatergoryId AND COPY.Barcode = @BARCODE AND BORROWER.PersonId= @PERSONID AND BORROW.Barcode = COPY.Barcode AND BORROW.PersonId = @PERSONID;");
            sqlIt.Command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@BARCODE", barcode),
                new SqlParameter("@PERSONID", personId)
            });

            try
            {
                sqlIt.Connection.Open();
                SqlDataReader dar = sqlIt.Command.ExecuteReader();
                if (dar.Read())
                {
                    _fine = (int)dar["Avgift"];
                    if (_fine <= 0)
                        _fine = 0;
                }
            }
            catch (Exception eObj)
            {
                throw new Exception("Database problem(s) when calculating fine!", eObj);
            }
            finally
            {
                if (sqlIt.Connection != null)
                    sqlIt.Connection.Close();
            }

            return _fine;
           
        }
    }
}

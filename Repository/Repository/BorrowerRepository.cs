using Repository.EntityModel;
using Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class BorrowerRepository : BaseRepository<borrower>
    {
        public static borrower GetBorrower(string PersonId)
        {
            return dbGet("SELECT * FROM BORROWER WHERE PersonId = @PERSONID;", new SqlParameter[] {
                new SqlParameter("@PERSONID", PersonId)
            });
        }

        public static List<borrower> GetBorrowers()
        {
            return dbGetList("SELECT * FROM BORROWER;", null);
        }

        public static void RemoveBorrower(borrower b)
        {
            dbPost("DELETE FROM BORROWER WHERE PersonId = @PERSONID;", new SqlParameter[] {
                new SqlParameter("@PERSONID", b.PersonId)
            });
        }

        public static void UpdateBorrower(borrower b)
        {
            dbPost("UPDATE BORROWER SET FirstName = @FIRSTNAME, LastName = @LASTNAME, Telno = @TELNO, Address = @ADDRESS, CategoryId = @CATEGORYID WHERE PersonId = @PERSONID", mapBorrowerParameters(b)
            );
        }

        private static SqlParameter[] mapBorrowerParameters(borrower b)
        {
            return new SqlParameter[] {
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    ParameterName = "@FIRSTNAME",
                    IsNullable = true,
                    Value = b.FirstName == null ? DBNull.Value.ToString() : b.FirstName
                },
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    ParameterName = "@LASTNAME",
                    IsNullable = true,
                    Value = b.LastName == null ? DBNull.Value.ToString() : b.LastName
                },
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    ParameterName = "@TELNO",
                    IsNullable = true,
                    Value = b.Telno == null ? DBNull.Value.ToString() : b.Telno
                },
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    ParameterName = "@ADDRESS",
                    IsNullable = true,
                    Value = b.Address == null ? DBNull.Value.ToString() : b.Address
                },
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    ParameterName = "@PERSONID",
                    IsNullable = false,
                    Value = b.PersonId
                },
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.Int,
                    ParameterName = "@CATEGORYID",
                    IsNullable = false,
                    Value = b.CategoryId
                }
            };
        }

        public static void StoreBorrower(borrower b)
        {
            dbPost("INSERT INTO BORROWER VALUES (@PERSONID, @FIRSTNAME, @LASTNAME, @ADDRESS, @TELNO, @CATEGORYID)", mapBorrowerParameters(b));
        }

        public static List<borrower> GetBorrowersByLetter(string letter)
        {
            return dbGetList("SELECT * FROM Borrower WHERE LastName LIKE @LETTER+'%';",
                new SqlParameter[] {
                    new SqlParameter("@LETTER", letter)
            });
        }
    }
}

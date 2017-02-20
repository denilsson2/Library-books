using Repository.EntityModel;
using Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class AuthorRepository : BaseRepository<author>
    {
        private static SqlParameter[] mapAuthorParameters(author a)

        {
            return new SqlParameter[] {
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    SqlValue = 50,
                    ParameterName = "@FIRSTNAME",
                    IsNullable = true,
                    Value = a.FirstName
                },
                new SqlParameter("@LASTNAME", a.LastName){
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    SqlValue = 50,
                    ParameterName = "@LASTNAME",
                    IsNullable = true,
                    Value = a.LastName
                },
                new SqlParameter("@BIRTHYEAR", a.BirthYear){
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    SqlValue = 10,
                    ParameterName = "@BIRTHYEAR",
                    IsNullable = true,
                    Value = a.BirthYear == null ? DBNull.Value.ToString() : a.BirthYear
                },
                new SqlParameter() {
                    SqlDbType = System.Data.SqlDbType.Int,
                    ParameterName = "@AID",
                    IsNullable = false,
                    Value = a.Aid
                }
            };
        }

        public static List<author> GetAuthors(string orderBy)
        {
            return dbGetList("SELECT * FROM Author ORDER BY "+orderBy+";", null);
        }

        public static List<author> GetAuthorsBySearch(string search)
        {
            return dbGetList("SELECT * FROM Author WHERE FirstName LIKE '%'+@SEARCH+'%' OR LastName LIKE '%'+@SEARCH+'%';",
                 new SqlParameter[] {
                    new SqlParameter("@SEARCH", search)
                 });
        }

        public static List<author> GetAuthorsByBookISBN(string isbn)
        {
            return dbGetList("SELECT * FROM BOOK_AUTHOR INNER JOIN AUTHOR ON BOOK_AUTHOR.Aid=AUTHOR.Aid WHERE BOOK_AUTHOR.ISBN = @ISBN", new SqlParameter[] {
                new SqlParameter("@ISBN", isbn)
            });
        }

        public static List<author> GetAuthorsByLetter(string letter)
        {
            return dbGetList("SELECT * FROM Author WHERE LastName LIKE @LETTER+'%';",
                 new SqlParameter[] {
                   new SqlParameter("@LETTER", letter)
                });
        }

        public static author GetAuthor(int aid)
        {
            return dbGet("SELECT * FROM author WHERE Aid = @AID;", new SqlParameter[] {
                new SqlParameter("@AID", aid)
            });
        }

        public static void UpdateAuthor(author a)
        {
            dbPost("UPDATE AUTHOR SET FirstName = @FIRSTNAME, LastName = @LASTNAME, BirthYear = @BIRTHYEAR WHERE Aid = @AID", mapAuthorParameters(a));
        }

        public static void StoreAuthor(author a)
        {
            dbPost("INSERT INTO AUTHOR VALUES (@FIRSTNAME, @LASTNAME, @BIRTHYEAR)", mapAuthorParameters(a));
        }

        public static void DeleteAuthor(author a)
        {
            dbPost("DELETE FROM AUTHOR WHERE Aid = @AID", new SqlParameter[] { 
                new SqlParameter("@AID", a.Aid)
            });
        }
    }
}

using Repository.EntityModel;
using Repository.Repository.Base;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class BookAuthorRepository : BaseRepository<bookAuthor>
    {
        public static bookAuthor GetBookAuthor(int Aid, string ISBN)
        {
            return dbGet("SELECT * FROM BOOK_AUTHOR WHERE Aid = @Aid AND ISBN = '@ISBN';", new SqlParameter[] {
                new SqlParameter("@AID", Aid),
                new SqlParameter("@ISBN", ISBN)
            });
        }

        public static void StoreBookAuthor(bookAuthor ba)
        {
            dbPost("INSERT INTO BOOK_AUTHOR VALUES (@ISBN, @Aid)", new SqlParameter[] {
                new SqlParameter("@ISBN", ba.ISBN),
                new SqlParameter("@Aid", ba.Aid)
            });
        }

        public static void RemoveBookAuthorByISBN(string isbn)
        {
            dbPost("DELETE FROM BOOK_AUTHOR WHERE ISBN = @ISBN", new SqlParameter[] {
                new SqlParameter("@ISBN", isbn)
            });
        }

        public static void RemoveBookAuthor(int Aid, string ISBN)
        {
            dbPost("DELETE FROM BOOK_AUTHOR WHERE ISBN = @ISBN AND Aid = @Aid", new SqlParameter[] {
                new SqlParameter("@ISBN", ISBN),
                new SqlParameter("@Aid", Aid)
            });
        }
    }
}

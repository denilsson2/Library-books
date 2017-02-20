using Repository.EntityModel;
using System.Data.SqlClient;
using Repository.Repository.Base;

namespace Repository.Repository
{
    public class StatusRepository : BaseRepository<Status>
    {
        public static Status GetStatusByStatusId(int statusId)
        {
            return dbGet("SELECT * FROM STATUS WHERE statusId = @STATUSID;", new SqlParameter[] {
                new SqlParameter("@STATUSID", statusId)
            });
        }

        public static Status GetStatusByISBN(string isbn)
        {
            return dbGet("SELECT * FROM COPY AS C, STATUS AS S WHERE C.StatusId = S.statusid AND C.ISBN = @ISBN", new SqlParameter[] {
                new SqlParameter("@ISBN", isbn)
            });
        }
    }
}

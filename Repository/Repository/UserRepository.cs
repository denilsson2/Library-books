using Repository.EntityModel;
using Repository.Repository.Base;
using System.Data.SqlClient;


namespace Repository.Repository
{
    public class UserRepository : BaseRepository<user>
    {
        public static user GetUserByPersonId(string personId)
        {
            return dbGet("SELECT * FROM \"USER\" WHERE PersonId = @PERSONID", new SqlParameter[] {
                new SqlParameter("@PERSONID", personId)
            });
        }

        public static user GetUserByEmail(string email)
        {
            return dbGet("SELECT * FROM \"USER\" WHERE Email = @EMAIL", new SqlParameter[]
            {
                new SqlParameter("@EMAIL", email)
            });
        }

        public static bool UserExists(string email)
        {
            return (dbGetProperty("SELECT Email FROM \"USER\" WHERE Email = @EMAIL", "Email", new SqlParameter[] {
                new SqlParameter("@EMAIL", email)
            }) != null ? true : false);
        }

        public static string GetPassword(string email)
        {
            return dbGet("SELECT * FROM \"USER\" WHERE Email = @EMAIL", new SqlParameter[] {
                new SqlParameter("@EMAIL", email)
            }).Password;
        }

        private static SqlParameter[] _mapUserParameters(user u)
        {
            return new SqlParameter[] { 
                new SqlParameter("@PERSONID", u.PersonId),
                new SqlParameter("@EMAIL", u.Email),
                new SqlParameter("@PASSWORD", u.Password),
                new SqlParameter("@ROLEID", u.RoleId)
            };
        }

        public static void CreateUser(user u)
        {
            dbPost("INSERT INTO \"USER\" VALUES (@PERSONID, @EMAIL, @PASSWORD, @ROLEID);", _mapUserParameters(u));
        }
        
        public static void RemoveUser(string PersonId){
            dbPost("DELETE FROM \"USER\" WHERE PersonId = @PERSONID;", new SqlParameter[] {
                new SqlParameter("@PERSONID", PersonId)
            });
        }
        
        public static void ChangePassword(string Password) 
        {
            //här ska det in ett anrop till databsen med det nya lösenordet
        }
        
        public static void UpdateUser(string personId, user u)
        {
            dbPost("UPDATE \"USER\" SET Email = @EMAIL, Password = @PASSWORD, RoleId=@ROLEID WHERE PersonId=@PERSONID;", _mapUserParameters(u));
        }
    }
}

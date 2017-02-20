using Repository.EntityModel;
using Repository.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class RoleRepository : BaseRepository<role>
    {
        public static List<role> GetRoles() {
            return dbGetList("SELECT * FROM \"ROLE\"", null);
        }

        public static role GetRoleByUserEmail(string email)
        {
            return dbGet("SELECT Id, Name FROM \"ROLE\" AS R INNER JOIN \"USER\" AS U ON R.Id = U.RoleId WHERE U.Email = @EMAIL", new SqlParameter[] {
                new SqlParameter("@EMAIL", email)
            });
        }

        public static role GetRoleById(int roleId)
        {
            return dbGet("SELECT * FROM \"ROLE\" WHERE RoleId = @ROLEID", new SqlParameter[] {
                new SqlParameter("@ROLEID", roleId)
            });
        }
    }
}

using Repository.EntityModel;
using Repository.Repository.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class CategoryRepository : BaseRepository<category>
    {
        public static List<category> GetCategories()
        {
            return dbGetList("SELECT * FROM CATEGORY", null);
        }

        public static category GetCategoryById(int categoryId)
        {
            return dbGet("SELECT * FROM CATEGORY WHERE CatergoryId = @CATEGORYID;", new SqlParameter[] {
                new SqlParameter("@CATEGORYID", categoryId)
            });
        }
 
    }
}

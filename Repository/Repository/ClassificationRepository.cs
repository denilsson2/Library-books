using Repository.EntityModel;
using Repository.Repository.Base;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class ClassificationRepository : BaseRepository<classification>
    {
        public static List<classification> GetClassifications()
        {
            return dbGetList("SELECT * FROM CLASSIFICATION", null);
        }
    }
}

using System.Collections.Generic;
using Repository.EntityModel;
using Common.Model.Base;

namespace Common.Model
{
    /// <summary>
    /// Used when creating a new borrower for adding a category, student, admin, extern and barn
    /// </summary>
    public class BorrowerAndCategories : BaseModel
    {
        public borrower Borrower { get; set; }
        public List<category> Categories { get; set; }
        public int CatergoryId { get; set; }
    }
}
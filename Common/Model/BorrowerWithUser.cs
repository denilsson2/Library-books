using Repository.EntityModel;

namespace Common.Model
{
    /// <summary>
    /// Holds a userinfo with it's permissions connected to a borrower
    /// </summary>
    public class BorrowerWithUser : Base.BaseModel
    {
        public borrower Borrower { get; set; }
        public user User { get; set; }
    }
}

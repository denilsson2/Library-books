using System.Collections.Generic;
using Repository.EntityModel;
using Common.Model.Base;

namespace Common.Model
{
    /// <summary>
    /// Used when creating a user account
    /// </summary>
    public class BorrowerWithBorrows : BaseModel
    {
        public BorrowerWithUser BorrowerWithUser { get; set; }
        public ActiveAndHistoryBorrows Borrows { get; set; }
        public List<category> Categories { get; set; }
        public List<role> Roles { get; set; }
    }
}
using Common.Model;
using Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Reflect users data through Session["User"]
    /// </summary>
    public class Auth
    {
        private BorrowerWithUser _loggedInUser = null;
        public BorrowerWithUser LoggedInUser {
            get
            {
                return _loggedInUser;
            } 
        }
        private string _alert = null;

        public Auth(BorrowerWithUser b)
        {
            _loggedInUser = b;
        }

        public bool HasAdminPermission()
        {
            if (HasUserPermission() && LoggedInUser.User.RoleId == 2)
                return true;

            return false;
        }

        public bool HasUserPermission()
        {
            if (LoggedInUser != null && LoggedInUser.User.RoleId >= 1)
                return true;

            return false;
        }

        public void PushAlert(string alertView)
        {
            _alert = alertView;
        }

        public string PopAlert()
        {
            string temp = _alert;
            _alert = null;
            return temp;
        }

        public bool IsAlerted()
        {
            return (_alert != null ? true : false);
        }

        public bool IsSameAs(BorrowerWithUser b, string newpassword)
        {
            if ((this.LoggedInUser.Borrower.Address == b.Borrower.Address) &&
                (this.LoggedInUser.Borrower.FirstName == b.Borrower.FirstName) &&
                (this.LoggedInUser.Borrower.CategoryId == b.Borrower.CategoryId) &&
                (this.LoggedInUser.Borrower.LastName == b.Borrower.LastName) &&
                (this.LoggedInUser.Borrower.Telno == b.Borrower.Telno) &&
                (newpassword == "") &&
                (this.LoggedInUser.User.Email == b.User.Email) &&
                (this.LoggedInUser.User.PersonId == b.User.PersonId) &&
                (this.LoggedInUser.User.RoleId == b.User.RoleId))
                return true;
            else
                return false;
        }
    }
}

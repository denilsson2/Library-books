using Common.Model;
using Common;
using Common.Share;
using Repository.EntityModel;
using System.Web.Mvc;
using Services.Service;
using Repository.Validation;


namespace MurvasBokhandel.Controllers.User
{
    public class UserController : Controller
    {
        public ActionResult Start() 
        {
            Auth _auth = new Auth((BorrowerWithUser)Session["User"]);
            if (_auth.HasUserPermission())
            {
                return View(UserService.GetActiveAndHistoryBorrows(_auth.LoggedInUser.User.PersonId));
            }

            return Redirect("/Error/Code/403");
        }

        // Lånar om de böcker som är möjliga att låna om
        public ActionResult ReloanAll() 
        {
            Auth _auth = new Auth((BorrowerWithUser)Session["User"]);
            if (_auth.HasUserPermission())
            {
                //OBS! Hämta lån innan
                ActiveAndHistoryBorrows borrows = UserService.GetActiveAndHistoryBorrows(_auth.LoggedInUser.User.PersonId);
                BorrowService.RenewAllLoans(_auth.LoggedInUser.Borrower, borrows.Active);

                return RedirectToAction("Start", borrows);
            }
            return Redirect("/Error/Code/403");
        }

        // Lånar om enskild bok
        public ActionResult Reloan(int index) 
        {
            Auth _auth = new Auth((BorrowerWithUser)Session["User"]);
            if (_auth.HasUserPermission()) 
            {
                ActiveAndHistoryBorrows borrows = UserService.GetActiveAndHistoryBorrows(_auth.LoggedInUser.User.PersonId);
                BorrowService.RenewLoad(_auth.LoggedInUser.Borrower, borrows.Active[index].Borrow.Barcode);

                return View("Start", borrows);
            }
            return Redirect("/Error/Code/403");
        }
        [HttpGet]
        public ActionResult GetAcountInfo()
        {
            Auth _auth = new Auth((BorrowerWithUser)Session["User"]);
            if (_auth.HasUserPermission())
                return View(BorrowerService.GetBorrowerWithUserByPersonId(_auth.LoggedInUser.User.PersonId));

            return Redirect("/Error/Code/403");
        }
              
        [HttpPost]
        public ActionResult GetAcountInfo(user user, borrower borrower, string newpassword = null)
        {
            //Knyter samman user och borrower -objekten
            BorrowerWithUser borrowerWithUser = new BorrowerWithUser()
            {
                User = user,
                Borrower = borrower
            };

            Auth _auth = new Auth((BorrowerWithUser)Session["User"]);

            if (_auth.HasUserPermission())
            {
                if (ModelState.IsValid)
                {
                    if (user.Password != null && PasswordService.VerifyPassword(user.Password, _auth.LoggedInUser.User.Password))
                    {
                        if (UserService.EmailExists(user.Email) && _auth.LoggedInUser.User.Email != user.Email)
                        {
                            borrowerWithUser.PushAlert(AlertView.Build("Email existerar. Försök igen!", AlertType.Danger));
                            return View(borrowerWithUser);
                        }

                        if (!_auth.IsSameAs(borrowerWithUser, newpassword))
                        {
                            if (newpassword == "")
                            {
                                UserService.Update(borrowerWithUser, user.Password);
                            }
                            else
                            {
                                if (!PasswordValidaton.IsValid(newpassword))
                                {
                                    borrowerWithUser.PushAlert(AlertView.Build(PasswordValidaton.ErrorMessage, AlertType.Danger));
                                    return View(borrowerWithUser);
                                }

                                UserService.Update(borrowerWithUser, newpassword);

                            }

                            borrowerWithUser.PushAlert(AlertView.Build("Du har uppdaterat ditt konto.", AlertType.Success));
                            Session["User"] = BorrowerService.GetBorrowerWithUserByPersonId(user.PersonId);

                            return View(borrowerWithUser);
                        }
                        else
                        {
                            borrowerWithUser.PushAlert(AlertView.Build("Inget har uppdaterats.", AlertType.Info));
                            return View(borrowerWithUser);
                        }
                    }

                    borrowerWithUser.PushAlert(AlertView.Build("Du måste ange ditt eget lösenord.", AlertType.Danger));
                    return View(borrowerWithUser);
                }

                return View(borrowerWithUser);
            }
            return Redirect("/Error/Code/403");               
        }
	}
}
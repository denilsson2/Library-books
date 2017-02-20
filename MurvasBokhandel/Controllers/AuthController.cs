using Common.Model;
using Common.Share;
using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (AuthService.Login(email, password))
            {
                BorrowerWithUser b = BorrowerService.GetBorrowerWithUserByEmail(email);
                Session["User"] = b;
                Session["Permissions"] = b.User.RoleId;

                return Redirect("/");
            }

            TempData["Alert"] = AlertView.Build("Fel email eller lösenord. Försök igen!", AlertType.Danger);

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return Redirect("/");
        }
    }
}
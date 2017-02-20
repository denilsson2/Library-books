using Common;
using Common.Model;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Start()
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
                return View();
                
            return Redirect("/");
        }
    }
}
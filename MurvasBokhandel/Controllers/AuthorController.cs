using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult GetAuthor(int aid)
        {
            if (!AuthorService.AuthorExists(aid))
                return Redirect("/Error/Code/404");

            return View(AuthorService.GetAuthorWithBooks(aid));
        }
    }
}
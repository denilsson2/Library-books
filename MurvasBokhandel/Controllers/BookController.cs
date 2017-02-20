using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult GetBook(string isbn)
        {
            if (!BookService.BookExists(isbn))
                return Redirect("/Error/Code/404");

            return View(BookService.GetBookWithAuthors(isbn));
        }
    }
}
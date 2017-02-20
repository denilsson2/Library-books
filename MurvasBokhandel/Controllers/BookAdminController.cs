using Common;
using Common.Model;
using Common.Share;
using Repository.EntityModel;
using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class BookAdminController : Controller
    {
        // GET: BookAdmin
        public ActionResult Start(string letter = "A")
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission() && LetterLists.LetterListWithNum.Contains(letter))
            {
                if (letter != "123")
                    return View(new LettersAndBooks(LetterLists.LetterListWithNum, BookService.GetBooksByLetter(letter)));
                else
                    return View(new LettersAndBooks(LetterLists.LetterListWithNum, BookService.GetBooksByNumber(LetterLists.NumbList)));
            }
            
            return Redirect("/Error/Code/403");
        }

        [HttpGet]
        public ActionResult Book(string id)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (!BookService.BookExists(id))
                    return Redirect("/Error/Code/404");

                return View(BookService.GetBookWithAuthorsAndAuthors(id));
            }
                
            return Redirect("/Error/Code/403");
        }

        [HttpPost]
        public ActionResult Book(book Book)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (ModelState.IsValid)
                {
                    BookService.UpdateBook(Book);

                    TempData["Alert"] = AlertView.Build("Du har uppdaterat bokens uppgifter", AlertType.Success);

                    return View(BookService.GetBookWithAuthorsAndAuthors(Book.ISBN));
                }

               TempData["Alert"] = AlertView.BuildErrors(ViewData);

                return View(BookService.GetBookWithAuthorsAndAuthors(Book.ISBN));
            }

            return Redirect("/Error/Code/403");
        }

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public ActionResult Remove(string isbn)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (!BookService.RemoveBook(isbn)) {

                    TempData["Alert"] = AlertView.Build("Det gick inte att ta bort bok. Kontrollera att det inte finns knutna lån eller författare.", AlertType.Danger);

                    return RedirectToAction("Book", new { id = isbn });
                }

                TempData["Alert"] = AlertView.Build("Boken med ISBN "+isbn+" är nu borttagen.", AlertType.Success);

                return RedirectToAction("Start");
            }

            return Redirect("/Error/Code/403");
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
                return View(BookService.NewBookWithClassifications());

            return Redirect("/Error/Code/403");
        }

        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="bwc"></param>
        /// <param name="copies"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(BookWithClassifications bwc, int copies, string library)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (ModelState.IsValid)
                {
                    BookService.StoreBook(bwc.Book, copies, library);

                    return RedirectToAction("Book", new { id = bwc.Book.ISBN });
                }

                TempData["Alert"] = AlertView.BuildErrors(ViewData);

                return View(BookService.NewBookWithClassifications());
            }

            return Redirect("/Error/Code/403");
        }

        public ActionResult AddAuthorToBook(int Aid, string isbn)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (!BookAuthorService.BookAuthorExists(Aid, isbn))
                    BookAuthorService.StoreBookAuthor(new bookAuthor() { Aid = Aid, ISBN = isbn });

                return RedirectToAction("Book", new { id = isbn });
            }
            return Redirect("/Error/Code/403");
        }

        public ActionResult RemoveAuthorFromBook(string ISBN, int Aid)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                BookAuthorService.RemoveBookAuthor(Aid, ISBN);

                return Redirect("/BookAdmin/Book/" + ISBN);
            }
            return Redirect("/Error/Code/403");
        }
    }
}
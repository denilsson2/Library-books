using Common;
using Common.Model;
using Common.Share;
using Repository.EntityModel;
using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class AuthorAdminController : Controller
    {        
        public ActionResult Start(string letter = "A")
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission() && LetterLists.LetterList.Contains(letter)) 
                return View(new LettersAndAuthors(LetterLists.LetterList, AuthorService.GetAuthorsByLetter(letter)));
            
            return Redirect("/Error/Code/403");            
        }

        [HttpGet]
        public ActionResult Author(int id)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (!AuthorService.AuthorExists(id))
                    return Redirect("/Error/Code/404");

                return View(AuthorService.GetAuthorWithBooksAndBooks(id));
            }

            return Redirect("/Error/Code/403");
        }

        [HttpPost]
        public ActionResult Author(AuthorWithBooksAndBooks a)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (ModelState.IsValid)
                {
                    AuthorService.UpdateAuthor(a.Author);

                    TempData["Alert"] = AlertView.Build("Du har uppdaterat författaren.", AlertType.Success);
                    return View(AuthorService.GetAuthorWithBooksAndBooks(a.Author.Aid));
                }

                return View(AuthorService.GetAuthorWithBooksAndBooks(a.Author.Aid));
            }

            return Redirect("/Error/Code/403");
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                return View();
            }

            return Redirect("/Error/Code/403");
        }

        /// <summary>
        /// Creates a new author
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(author a)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission()) 
            {
                if (ModelState.IsValid)
                {
                    AuthorService.StoreAuthor(a);
                    TempData["Alert"] = AlertView.Build("Du har skapat författaren "+a.FirstName+" "+a.LastName, AlertType.Success);
                    return RedirectToAction("Start");
                }

                return View(a);
            }


            return Redirect("/Error/Code/403");
        }

        /// <summary>
        /// Removes an author
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public ActionResult Remove(AuthorWithBooks a)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                AuthorService.DeleteAuthor(a.Author);
                TempData["Alert"] = AlertView.Build("Du har tagit bort författaren "+a.Author.FirstName+" "+a.Author.LastName, AlertType.Success);
                return RedirectToAction("Start");
            }

            return Redirect("/Error/Code/403");
        }

        public ActionResult AddBookToAuthor(int Aid, string ISBN)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                if (!BookAuthorService.BookAuthorExists(Aid, ISBN))
                    BookAuthorService.StoreBookAuthor(new bookAuthor()
                    {
                        ISBN = ISBN,
                        Aid = Aid
                    });

                return Redirect("Author/" + Aid);
            }

            return Redirect("/Error/Code/403");
        }

        public ActionResult RemoveBookFromAuthor(int Aid, string ISBN)
        {
            if (new Auth((BorrowerWithUser)Session["User"]).HasAdminPermission())
            {
                BookAuthorService.RemoveBookAuthor(Aid, ISBN);

                return Redirect("Author/" + Aid);
            }

            return Redirect("/Error/Code/403");
        }
    }
}
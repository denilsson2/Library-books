using Common.Model;
using Common.Share;
using Services.Service;
using System.Web.Mvc;


namespace MurvasBokhandel.Controllers
{
    public class PublicController : Controller
    {
        
        public ActionResult Start()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search_field)
        {
            return View(AuthorService.GetSearchResult(search_field));
        }

        
        [HttpGet]
        public ActionResult BrowseAuthor(string letter ="A")
        {
            if (LetterLists.LetterList.Contains(letter))
                return View(new LettersAndAuthors(LetterLists.LetterList, AuthorService.GetAuthorsByLetter(letter)));

            return Redirect("/");
        }

        
        [HttpGet]
        public ActionResult BrowseBook(string letter = "A")
        {
            if (LetterLists.LetterListWithNum.Contains(letter))
            {
                if (letter == "123")
                    return View(new LettersAndBooks(LetterLists.LetterListWithNum, BookService.GetBooksByNumber(LetterLists.NumbList)));
                
                return View(new LettersAndBooks(LetterLists.LetterListWithNum, BookService.GetBooksByLetter(letter)));
            }
            return Redirect("/");
        }
    }
}
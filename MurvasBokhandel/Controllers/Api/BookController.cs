using Newtonsoft.Json;
using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers.Api
{
    public class BookController : Controller
    {
        public string Get(string id)
        {
            return JsonConvert.SerializeObject(BookService.GetBook(id));
        }

        public string Search(string id)
        {
            return JsonConvert.SerializeObject(BookService.GetBooksBySearch(id));
        }
    }
}
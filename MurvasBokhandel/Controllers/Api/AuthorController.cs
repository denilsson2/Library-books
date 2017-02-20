using Newtonsoft.Json;
using Services.Service;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers.Api
{
    public class AuthorController : Controller
    {
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(AuthorService.GetAuthorWithBooks(id));
        }
    }
}
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers.Api
{
    public class FileController : Controller
    {
        [HttpGet]
        public FileContentResult Widget(string id)
        {
            if (id == "js")
                return File(System.IO.File.ReadAllBytes(Server.MapPath("~/Scripts/Widget/widget.js")), "text/javascript");
            else if (id == "html") 
                return File(System.IO.File.ReadAllBytes(Server.MapPath("~/Scripts/Widget/search-widget.html")), "text/javascript");

            return null;
        }
    }
}
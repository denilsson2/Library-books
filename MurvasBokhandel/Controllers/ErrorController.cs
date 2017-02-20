using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Code(string id)
        {
            switch (id)
            {
                case "404":
                    ViewBag.Error_header = "Sidan kunde inte hittas!";
                    ViewBag.Error_body = "Tyvärr kunde inte sidan du sökte hittas. Vänligen kontakta oss om något verkar fel.";
                    break;
                case "403":
                    ViewBag.Error_header = "Tillträde förbjudet!";
                    ViewBag.Error_body = "Du har inte tillträde till denna sidan. Kontrollera att du är inloggad med rätt konto.";
                    break;
            }

            return View();
        }

        public ActionResult NotFound()
        {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (!Request.IsAjaxRequest())
                result = View(model);
            else
                result = PartialView("_NotFound", model);

            return result;
        }
    }
}
// DansTesComs -> DansTesComs.WebSite ->HomeController.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System.Web.Mvc;

namespace DansTesComs.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
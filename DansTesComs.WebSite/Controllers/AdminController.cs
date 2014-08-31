using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DansTesComs.WebSite.Filters;

namespace DansTesComs.WebSite.Controllers
{
    [InitializeSimpleMembership]
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
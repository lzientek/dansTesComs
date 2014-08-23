using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DansTesComs.Core.Models;
using PagedList;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{

    public class SearchController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();

        private const int NbResultPerPage = 20;

        // GET: Search
        public ActionResult Index(string searchText, int page = 1)
        {

            var results = FindResults(searchText);
            var search = new Search();
            search.SearchText = searchText;
            search.NbResult = results.Count;
            search.DateRecherche = DateTime.Now;
            if (WebSecurity.IsAuthenticated) { search.UserId = WebSecurity.CurrentUserId; }
            db.Searches.Add(search);
            db.SaveChanges();

            ViewBag.Recherche = search.SearchText;
            ViewBag.NbResult = search.NbResult;

            return View(results.ToPagedList(page, NbResultPerPage));
        }



        private List<SearchResult> FindResults(string search)
        {
            return new List<SearchResult>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

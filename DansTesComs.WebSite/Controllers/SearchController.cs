using System;
using System.Collections.Generic;
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

        private const int NbResultPerPage = 10;

        // GET: Search
        public ActionResult Index(string searchText, int page = 1)
        {

            var results = FindResults(searchText.Split(' '));
            var search = new Search {SearchText = searchText, NbResult = results.Count, DateRecherche = DateTime.Now};
            if (WebSecurity.IsAuthenticated) { search.UserId = WebSecurity.CurrentUserId; }
            db.Searches.Add(search);
            db.SaveChanges();

            ViewBag.Recherche = search.SearchText;
            ViewBag.NbResult = search.NbResult;

            return View(results.ToPagedList(page, NbResultPerPage));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SearchPost(string searchText)
        {
            return RedirectToAction("Index", new { searchText = searchText });
        }


        public List<SearchResult> FindResults(IEnumerable<string> searches)
        {
            var partialList = new List<CommentaireExterne>();
            foreach (var search in searches)
            {
                partialList.AddRange(db.CommentaireExternes.Where(
                    c =>
                        c.Titre.Contains(search) ||
                        c.Publication.Contains(search) ||
                        c.CommentairesExterneContents.Any(ce => ce.Commentaire.Contains(search))));
            }
            var resultList = partialList.Distinct().Select(commentaireExterne => new SearchResult(commentaireExterne, Url.Action("Details", "CommentaireExternes", new {id = commentaireExterne.Id})) {Importance = partialList.Count(c => c == commentaireExterne)}).ToList();
            resultList.Sort(new SearchResultComparer());
            return resultList;
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

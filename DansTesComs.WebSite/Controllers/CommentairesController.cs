using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DansTesComs.Core.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
    public class CommentairesController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();


        public ActionResult Index(int extCommentId, int page = 1)
        {
            var commentaires = db.Commentaires.Where(c => c.PostId == extCommentId).ToList().ToPagedList(page, 3);
            ViewBag.commentid = extCommentId;
            return PartialView(commentaires);
        }


        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();                
            }
            return new EmptyResult();;
        }

        // POST: Commentaires/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "Texte,PostId")] Commentaire commentaire)
        {
            
            commentaire.DatePost = DateTime.Now;
            commentaire.UserId = WebSecurity.CurrentUserId;
            if (ModelState.IsValid)
            {
                db.Commentaires.Add(commentaire);
                db.SaveChanges();
                return PartialView("_PartialViewCommentaire",commentaire);
            }

            return View(commentaire);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = db.Commentaires.Find(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commentaire commentaire = db.Commentaires.Find(id);
            db.Commentaires.Remove(commentaire);
            db.SaveChanges();
            return RedirectToAction("Index");
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

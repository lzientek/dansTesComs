using System;
using System.Collections.Generic;
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
            var commentaires = db.Commentaires.Where(c => c.PostId == extCommentId).OrderByDescending(c=>c.DatePost).ToList().ToPagedList(page, 10);
            ViewBag.commentid = extCommentId;
            return PartialView(commentaires);
        }


        public ActionResult Create(int commentaireId)
        {
            if (Request.IsAuthenticated)
            {
                
                var com = new Commentaire {User = db.Users.Find(WebSecurity.CurrentUserId)};
                com.PostId = commentaireId;
                return PartialView(com);                
            }
            return new EmptyResult();
        }

        // POST: Commentaires/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult Create([Bind(Include = "Texte,PostId")] Commentaire commentaire)
        {
            
            commentaire.DatePost = DateTime.Now;
            commentaire.UserId = WebSecurity.CurrentUserId;
            commentaire.Texte = WebUtility.HtmlEncode(commentaire.Texte);
            if (ModelState.IsValid)
            {
                db.Commentaires.Add(commentaire);
                db.SaveChanges();
                commentaire.User = db.Users.Find(commentaire.UserId);
                return PartialView("_PartialViewCommentaire",commentaire);
            }

            return View(commentaire);
        }

        [Authorize(Roles = "Admin")]
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
            db.NotesCommentaires.RemoveRange(commentaire.NotesCommentaires);
            db.Commentaires.Remove(commentaire);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin(int page = 1)
        {
            var commentaires =
                db.Commentaires.Where(c => c.NotesCommentaires.Any(nc => nc.Value == 9)).OrderByDescending(cm=>cm.NotesCommentaires.Count(nc=>nc.Value == 9)).ToList().ToPagedList(page, 50);
            return View(commentaires);
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

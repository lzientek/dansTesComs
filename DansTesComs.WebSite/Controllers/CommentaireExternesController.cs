using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DansTesComs.WebSite.Filters;
using DansTesComs.WebSite.Models;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
    [InitializeSimpleMembership]
    public class CommentaireExternesController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();

        public ActionResult Index()
        {
            var commentaireExternes = db.CommentaireExternes.Include(c => c.User);
            return View(commentaireExternes.ToList());
        }


        //[Authorize(Roles = "Modo")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentaireExterne commentaireExterne = db.CommentaireExternes.Find(id);
            if (commentaireExterne == null)
            {
                return HttpNotFound();
            }
            return View(commentaireExterne);
        }

        //[Authorize(Roles = "Modo")]
        //[Authorize(Roles = "ADVuser")]
        public ActionResult Create()
        {
            var com = new CommentaireExterne();
            com.CommentairesExterneContents.Add(new CommentairesExterneContent{Commentaire = string.Empty,Pseudo = string.Empty,Niveau = 0});
            return View(com);
        }


        [HttpPost]
        //[Authorize(Roles = "Modo")]
        [Authorize]        
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentairesExterneContents,Lien,Titre")] CommentaireExterne commentaireExterne)
        {
            commentaireExterne.DatePost = DateTime.Now;
            commentaireExterne.PosterUserId = WebSecurity.CurrentUserId;
            if (ModelState.IsValid)
            {
                try
                {
                    db.CommentaireExternes.Add(commentaireExterne);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View(commentaireExterne);
                }

                return RedirectToAction("Index");
            }

            return View(commentaireExterne);
        }

        // GET: CommentaireExternes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentaireExterne commentaireExterne = db.CommentaireExternes.Find(id);
            if (commentaireExterne == null)
            {
                return HttpNotFound();
            }
            ViewBag.PosterUserId = new SelectList(db.Users, "Id", "Mail", commentaireExterne.PosterUserId);
            return View(commentaireExterne);
        }

        // POST: CommentaireExternes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Contenu,PosterUserId,DatePost")] CommentaireExterne commentaireExterne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentaireExterne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PosterUserId = new SelectList(db.Users, "Id", "Mail", commentaireExterne.PosterUserId);
            return View(commentaireExterne);
        }

        // GET: CommentaireExternes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentaireExterne commentaireExterne = db.CommentaireExternes.Find(id);
            if (commentaireExterne == null)
            {
                return HttpNotFound();
            }
            return View(commentaireExterne);
        }

        // POST: CommentaireExternes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentaireExterne commentaireExterne = db.CommentaireExternes.Find(id);
            db.CommentaireExternes.Remove(commentaireExterne);
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

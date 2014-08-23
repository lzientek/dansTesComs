using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DansTesComs.Core.Models;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
    public class NewsLettersController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();

        // GET: NewsLetters
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var newsLetters = db.NewsLetters.Include(n => n.User);
            return View(newsLetters.ToList());
        }

        // GET: NewsLetters/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Mail")] NewsLetter newsLetter)
        {
            newsLetter.InscriptionDate = DateTime.Now;
            newsLetter.User = db.Users.SingleOrDefault(u => u.Mail == newsLetter.Mail);
            if (ModelState.IsValid)
            {
                db.NewsLetters.Add(newsLetter);
                db.SaveChanges();
                return PartialView("ValidNews");
            }
            return PartialView(newsLetter);
        }

        [HttpPost]
        public ActionResult CreateConnected()
        {
            var newsLetter = new NewsLetter();
            var user = db.Users.Find(WebSecurity.CurrentUserId);
            newsLetter.Mail = user.Mail;
            newsLetter.User = user;
            newsLetter.InscriptionDate = DateTime.Now;

            db.NewsLetters.Add(newsLetter);
            db.SaveChanges();
            return PartialView("ValidNews");
        }

       

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            if (newsLetter == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Mail", newsLetter.UserId);
            return View(newsLetter);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mail,UserId,InscriptionDate")] NewsLetter newsLetter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsLetter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Mail", newsLetter.UserId);
            return View(newsLetter);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            if (newsLetter == null)
            {
                return HttpNotFound();
            }
            return View(newsLetter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewsLetter newsLetter = db.NewsLetters.Find(id);
            db.NewsLetters.Remove(newsLetter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public bool IsUserSubscribe()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return db.Users.Find(WebSecurity.CurrentUserId).NewsLetters.Count > 0;                
            }
            return false;
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

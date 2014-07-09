﻿// DansTesComs -> DansTesComs.WebSite ->UserController.cs
// fichier créée le 08/07/2014 a 22:13
// par lucas zientek ( lucas )

using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DansTesComs.WebSite.Filters;
using DansTesComs.WebSite.Models;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UserController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();

        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // POST: User
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(
            [Bind(Include = "Mail,Nom,Prenom,Anniversaire,Pseudo,Pass")] User user)
        {
            user.InscriptionDate = DateTime.Now;
            user.IsAdmin = false;
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "id,mail,nom,prenom,Anniversaire,InscriptionDate,isAdmin,pass")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //GET: User/Connexion
        [ActionName("Connexion")]
        [AllowAnonymous]
        public ActionResult Connexion()
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Connexion")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion([Bind(Include = "Mail,Pass,RememberMe")] User user)
        {
            var userToConnect = db.Users.First(u => u.Mail == user.Mail && u.Pass == user.Pass);
            if(userToConnect != null && WebSecurity.Login(userToConnect.Pseudo,userToConnect.Pass,user.RememberMe))
                return RedirectToAction("Index","Home");
            else
            {
                return RedirectToAction("Connexion");
            }
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
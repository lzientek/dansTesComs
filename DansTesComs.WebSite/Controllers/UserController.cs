// DansTesComs -> DansTesComs.WebSite ->UserController.cs
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

        // GET: User/Details
        public ActionResult Details()
        {
            User user = db.Users.Find(WebSecurity.CurrentUserId);
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
                WebSecurity.CreateAccount(user.Pseudo, user.Pass);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit
        public ActionResult Edit()
        {
            User user = db.Users.Find(WebSecurity.CurrentUserId);
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
            [Bind(Include = "id,mail,nom,prenom,Anniversaire")] User user)
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
            var userToConnect = db.Users.First(u => u.Mail == user.Mail).Pseudo;
            if(userToConnect != null && WebSecurity.Login(userToConnect,user.Pass,user.RememberMe))
                return RedirectToAction("Index","Home");
            return RedirectToAction("Connexion");
        }


        public ActionResult Deconnexion()
        {
            WebSecurity.Logout();
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
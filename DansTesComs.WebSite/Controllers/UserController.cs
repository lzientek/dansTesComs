// DansTesComs -> DansTesComs.WebSite ->UserController.cs
// fichier créée le 08/07/2014 a 22:13
// par lucas zientek ( lucas )

using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using DansTesComs.Ressources.User;
using DansTesComs.WebSite.Filters;
using DansTesComs.Core.Models;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
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
            if (ModelState.IsValid && !WebSecurity.UserExists(user.Pseudo))
            {

                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    WebSecurity.CreateAccount(user.Pseudo, user.Pass);

                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [Authorize]
        public ActionResult Edit()
        {
            User user = db.Users.Find(WebSecurity.CurrentUserId);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Mail,Nom,Prenom,Anniversaire")] User user)
        {
            var userinDb = db.Users.First(u => u.Id == WebSecurity.CurrentUserId);
            userinDb.Mail = user.Mail;
            userinDb.Nom = user.Nom;
            userinDb.Prenom = user.Prenom;
            userinDb.Anniversaire = user.Anniversaire;

            //todo: un modele herité pour avoir classe uniquement pour inscription voir connexion
            userinDb.Pass = "passbidoncarsinoncaplantejecroisqueje vais changer le modele";
            try
            {
                db.SaveChanges();
                ViewBag.IsEnregistrer = UserRessources.ModifSave;
            }
            catch (DbEntityValidationException exception)
            {
                ViewBag.IsEnregistrer = exception.Message;
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

        [HttpPost, ActionName("Connexion")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion([Bind(Include = "Mail,Pass,RememberMe")] User user)
        {
            var userToConnect = db.Users.First(u => u.Mail == user.Mail).Pseudo;
            if (userToConnect != null && WebSecurity.Login(userToConnect, user.Pass, user.RememberMe))
                return RedirectToAction("Index", "Home");
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
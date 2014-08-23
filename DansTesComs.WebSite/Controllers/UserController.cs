// DansTesComs -> DansTesComs.WebSite ->UserController.cs
// fichier créée le 08/07/2014 a 22:13
// par lucas zientek ( lucas )

using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DansTesComs.Core.Models.ModelsExtentions;
using DansTesComs.Ressources.General;
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
        private const string returnUrlCookie = "returnUrl";

        // GET: User
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl = null,int messageType = 1)
        {
            if (ReturnUrl != null)
            {
                SetCookieReturnUrl(ReturnUrl);
                switch (messageType)
                {
                    case 1:
                        ViewBag.PageConnectionNeed = string.Format("{0} {1}{2}.", GeneralRessources.ConnectionPourPage, Request.Url.Host, ReturnUrl);
                        break;
                    default:
                        ViewBag.PageConnectionNeed = string.Empty;
                        break;
                }
            }
            return View();
        }

        private void SetCookieReturnUrl(string ReturnUrl)
        {
            var cookie = new HttpCookie(returnUrlCookie, ReturnUrl);
            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
        }

        public ActionResult Details()
        {
            var user = db.Users.Find(WebSecurity.CurrentUserId);
            if (user == null)
            {
                return RedirectToAction("Index");
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
            [Bind(Include = "Mail,Nom,Prenom,Anniversaire,Pseudo,Pass")] UserPass user)
        {
            user.InscriptionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var usr = user.ToUser();
                try
                {
                    db.Users.Add(usr);
                    db.SaveChanges();
                    WebSecurity.CreateAccount(user.Pseudo, user.Pass);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return RedirectToAction("Connexion", new { creationCompte = true});
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
            var userinDb = db.Users.Find(WebSecurity.CurrentUserId);
            userinDb.Mail = user.Mail;
            userinDb.Nom = user.Nom;
            userinDb.Prenom = user.Prenom;
            if (user.Anniversaire != null)
                userinDb.Anniversaire = user.Anniversaire;

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
        public ActionResult Connexion(bool creationCompte = false)
        {
            if (creationCompte)
            {
                ViewBag.Creation = UserRessources.NewUserAdd;
            }
            return View();
        }

        [HttpPost, ActionName("Connexion")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion([Bind(Include = "Mail,Pass,RememberMe")] UserConnexion user, string ReturnUrl =null)
        {

            if (db.Users.Any(u => u.Mail == user.Mail))
            {
                var userToConnect = db.Users.Single(u => u.Mail == user.Mail);
                if (userToConnect != null && WebSecurity.Login(userToConnect.Pseudo, user.Pass, user.RememberMe))
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    HttpCookie cookie = ControllerContext.HttpContext.Request.Cookies[returnUrlCookie];

                    if (cookie != null)
                    {
                        string action = cookie.Value;
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                        return Redirect(action);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Connexion");
        }


        public ActionResult Deconnexion()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult IsUserEmailAvailable(string Mail)
        {
            return Json(!db.Users.Any(u => u.Mail == Mail), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult IsUserPseudoAvailable(string Pseudo)
        {
            return Json(!db.Users.Any(u => u.Pseudo == Pseudo), JsonRequestBehavior.AllowGet);
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
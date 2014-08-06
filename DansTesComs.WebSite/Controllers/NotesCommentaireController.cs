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
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
    public class NotesCommentaireController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();

        // GET: Notes
        public ActionResult Index(int commentaireId)
        {
            ViewBag.commentaireId = commentaireId;
            var notes = db.NotesCommentaires.Where(n=>n.CommentaireId == commentaireId);
            return PartialView(notes.ToList());
        }


        private void Save(NotesCommentaire note)
        {
            note.UserId = WebSecurity.CurrentUserId;

            NotesCommentaire noteModif;
            if ( (noteModif = db.NotesCommentaires.FirstOrDefault(n=>n.UserId == note.UserId && n.CommentaireId==note.CommentaireId))  != null )
            {
                if (noteModif.Value == note.Value)// si les valeurs sont egals on supprime
                {
                    db.NotesCommentaires.Remove(noteModif);
                }
                else //sinon on change de valeurs
                {
                    noteModif.Value = note.Value;
                }
                db.SaveChanges();
                
            }
            else if (ModelState.IsValid)
            {
                db.NotesCommentaires.Add(note);
                db.SaveChanges();
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult Plus(int commentaireId)
        {
            var note = new NotesCommentaire()
            {
                NoteValue = NoteValue.Plus,
                CommentaireId = commentaireId,
            };
             Save(note);
            return RedirectToAction("Index", new {@commentaireId = commentaireId});
        }

        [HttpPost]
        [Authorize]
        public ActionResult Moins(int commentaireId)
        {
            var note = new NotesCommentaire()
            {
                NoteValue = NoteValue.Moins,
                CommentaireId = commentaireId
            };

            Save(note);
            return RedirectToAction("Index", new { @commentaireId = commentaireId });

        }

        [HttpPost]
        [Authorize]
        public ActionResult Signaler(int commentaireId)
        {
            var note = new NotesCommentaire()
            {
                NoteValue = NoteValue.Signaler,
                CommentaireId = commentaireId
            };

            Save(note);
            return RedirectToAction("Index", new { @commentaireId = commentaireId });

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

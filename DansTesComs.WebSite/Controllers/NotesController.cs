using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DansTesComs.WebSite.Models;
using Microsoft.Ajax.Utilities;
using WebMatrix.WebData;

namespace DansTesComs.WebSite.Controllers
{
    public class NotesController : Controller
    {
        private DansTesComsEntities db = new DansTesComsEntities();

        // GET: Notes
        public ActionResult Index(int commentaireExterneId)
        {
            ViewBag.commentaireId = commentaireExterneId;
            var notes = db.Notes.Where(n=>n.IdCommentaire == commentaireExterneId);
            return PartialView(notes.ToList());
        }


        private void Save(Note note)
        {
            note.IdUser = WebSecurity.CurrentUserId;

            Note noteModif;
            if ( (noteModif = db.Notes.FirstOrDefault(n=>n.IdUser == note.IdUser && n.IdCommentaire==note.IdCommentaire))  != null )
            {
                if (noteModif.NoteValue == note.NoteValue)// si les valeurs sont egals on supprime
                {
                    db.Notes.Remove(noteModif);
                }
                else //sinon on change de valeurs
                {
                    noteModif.NoteValue = note.NoteValue;
                }
                db.SaveChanges();
                
            }
            else if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                db.SaveChanges();
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult Plus(int commentaireExterneId)
        {
            var note = new Note
            {
                NoteValue = NoteValue.Plus,
                IdCommentaire = commentaireExterneId,
            };
             Save(note);
            return RedirectToAction("Index", new {@commentaireExterneId = commentaireExterneId});
        }

        [HttpPost]
        [Authorize]
        public ActionResult Moins(int commentaireExterneId)
        {
            var note = new Note
            {
                NoteValue = NoteValue.Moins,
                IdCommentaire = commentaireExterneId
            };

            Save(note);
            return RedirectToAction("Index", new { @commentaireExterneId = commentaireExterneId });

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

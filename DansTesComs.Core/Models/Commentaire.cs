//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DansTesComs.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commentaire
    {
        public Commentaire()
        {
            this.NotesCommentaires = new HashSet<NotesCommentaire>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Texte { get; set; }
        public System.DateTime DatePost { get; set; }
        public int PostId { get; set; }
    
        public virtual User User { get; set; }
        public virtual CommentaireExterne CommentaireExterne { get; set; }
        public virtual ICollection<NotesCommentaire> NotesCommentaires { get; set; }
    }
}

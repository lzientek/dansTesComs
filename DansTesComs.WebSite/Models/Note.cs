//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DansTesComs.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Note
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int IdCommentaire { get; set; }
        public int IdUser { get; set; }
    
        public virtual CommentaireExterne CommentaireExterne { get; set; }
        public virtual User User { get; set; }
    }
}
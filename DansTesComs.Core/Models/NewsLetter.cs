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
    
    public partial class NewsLetter
    {
        public string Mail { get; set; }
        public Nullable<int> UserId { get; set; }
        public System.DateTime InscriptionDate { get; set; }
    
        public virtual User User { get; set; }
    }
}
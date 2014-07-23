using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DansTesComs.WebSite.Models
{
    [MetadataType(typeof(CommentaireMetaData))]
    public partial class Commentaire
    {
    }

    public class CommentaireMetaData
    {
        [MaxLength(600, ErrorMessage = "Ne peut pas dépacer 600 caractères.")]
        [Required(ErrorMessage = "Mettez du text :)")]
        [DataType(DataType.MultilineText)]
        public string Texte { get; set; }

    }
}
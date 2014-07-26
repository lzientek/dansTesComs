using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DansTesComs.Ressources.CommentaireExterne;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof(CommentaireMetaData))]
    public partial class Commentaire
    {
    }

    public class CommentaireMetaData
    {
        [MaxLength(600, ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName ="LongueurMax600" )]
        [Required(ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "CommentaireNonVide")]
        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(CommentaireExterneRessources), Name = "CommentaireLabel")]
        public string Texte { get; set; }

    }
}
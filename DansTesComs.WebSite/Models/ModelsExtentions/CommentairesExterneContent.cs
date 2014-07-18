using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DansTesComs.WebSite.Models
{
    [MetadataType(typeof(CommentairesExterneContentMetaData))]
    public partial class CommentairesExterneContent
    {
    }

    public class CommentairesExterneContentMetaData
    {
        [MaxLength(50, ErrorMessage = "Pseudo trop long!")]
        [Required]
        public string Pseudo { get; set; }

        [Required]
        public string Commentaire { get; set; }

        [Range(0,4)]
        [Required]
        public int Niveau { get; set; }
    }
}
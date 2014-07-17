using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DansTesComs.WebSite.Models
{
    public partial class CommentairesExterneContent
    {
    }

    public class CommentairesExterneContentMetaData
    {
        [MaxLength(50, ErrorMessage = "Pseudo trop long!")]
        public string Pseudo { get; set; }
        
        [Range(0,4)]
        public int Niveau { get; set; }
    }
}
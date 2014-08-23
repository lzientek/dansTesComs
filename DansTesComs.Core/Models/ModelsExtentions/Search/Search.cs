using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Ressources.CommentaireExterne;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof(SearchMetaData))]
    public partial class Search
    {
    }

    public class SearchMetaData
    {
        [MaxLength(100, ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "LongueurMax600")]
        [Required(ErrorMessageResourceType = typeof(CommentaireExterneRessources), ErrorMessageResourceName = "CommentaireNonVide")]
        [Display(ResourceType = typeof(CommentaireExterneRessources), Name = "CommentaireLabel")]
        public string SearchText { get; set; }

    }
}

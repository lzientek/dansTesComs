using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Ressources.CommentaireExterne;
using DansTesComs.Ressources.General;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof(SearchMetaData))]
    public partial class Search
    {
    }

    public class SearchMetaData
    {
        [MaxLength(100, ErrorMessageResourceType = typeof(SearchRessources), ErrorMessageResourceName = "SearchTextt100")]
        [Required(ErrorMessageResourceType = typeof(SearchRessources), ErrorMessageResourceName = "SearchTextNotEmpty")]
        [Display(ResourceType = typeof(SearchRessources), Name = "FaireUneRecherche")]
        public string SearchText { get; set; }

    }
}

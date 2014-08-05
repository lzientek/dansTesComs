using System.ComponentModel.DataAnnotations;
using DansTesComs.Ressources.CommentaireExterne;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof(CommentairesExterneContentMetaData))]
    public partial class CommentairesExterneContent
    {
        
    }

    public class CommentairesExterneContentMetaData
    {
        [MaxLength(50, ErrorMessageResourceType = typeof(CommentaireExterneRessources),ErrorMessageResourceName = "LongueurMax50")]
        [Required]
        [Display(ResourceType = typeof(CommentaireExterneRessources), Name = "Pseudo")]
        public string Pseudo { get; set; }

        [Required]
        [Display(ResourceType = typeof(CommentaireExterneRessources), Name = "CommentaireLabel")]
        public string Commentaire { get; set; }

        [Range(0,4)]
        [Required]
        public int Niveau { get; set; }
    }
}
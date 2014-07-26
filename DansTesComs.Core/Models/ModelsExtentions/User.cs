// DansTesComs -> DansTesComs.WebSite ->UserExt.cs
// fichier créée le 09/07/2014 a 19:56
// par lucas zientek ( lucas )

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DansTesComs.Core.Attribute.DateValidator;
using DansTesComs.Ressources.User;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof (UserMetadata))]
    public partial class User
    {
        public bool RememberMe { get; set; }
        public string Pass { get; set; }
    }


    public class UserMetadata
    {
        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError",ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        public string Mail { get; set; }

        [MaxLength(80, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "LongueurMax80")]
        [Display(ResourceType = typeof(UserRessources), Name = "NomLabel")]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "NomObligatoire")]
        public string Nom { get; set; }

        [MaxLength(80, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "LongueurMax80")]
        [Display(ResourceType = typeof(UserRessources), Name = "PrenomLabel")]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PrenomObligatoire")]
        public string Prenom { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PassObligatoire")]
        [Display(ResourceType = typeof(UserRessources), Name = "PassLabel")]
        public string Pass { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "AnniversaireLabel")]
        [DataType(DataType.Date)]
        [AgeMinimum(13,ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "MinAgeError")]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "AnnivObligatoire")]
        public DateTime Anniversaire { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PseudoObligatoire")]
        [Display(ResourceType = typeof(UserRessources), Name = "PseudoLabel")]
        [RegularExpression(RegexPattern.PseudoValidRegex, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PseudoRegex")]
        public string Pseudo { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "RememberMeLabel")]
        public bool RememberMe { get; set; }
    }
}
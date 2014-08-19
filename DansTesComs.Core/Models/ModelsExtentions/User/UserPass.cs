using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Core.Attribute.DateValidator;
using DansTesComs.Ressources.User;

namespace DansTesComs.Core.Models.ModelsExtentions
{
    [MetadataType(typeof(UserPassMetadata))]
    public class UserPass : User
    {
        public string Pass { get; set; }

        public User ToUser()
        {
            return new User
            {
                Anniversaire = this.Anniversaire,
                Id = Id,
                InscriptionDate = InscriptionDate,
                Mail = Mail,
                Nom = Nom,
                Pseudo = Pseudo,
                Prenom = Prenom,

            };
        }
    }

    public class UserPassMetadata:UserMetadata
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof (UserRessources), ErrorMessageResourceName = "PassObligatoire")]
        [Display(ResourceType = typeof (UserRessources), Name = "PassLabel")]
        public string Pass { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError", ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        [System.Web.Mvc.Remote("IsUserEmailAvailable", "User",ErrorMessageResourceType = typeof(UserRessources),ErrorMessageResourceName = "MailDejaUtilise")]
        public string Mail { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "AnniversaireLabel")]
        [DataType(DataType.Date)]
        [AgeMinimum(13, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "MinAgeError")]
        public DateTime Anniversaire { get; set; }
    }
}

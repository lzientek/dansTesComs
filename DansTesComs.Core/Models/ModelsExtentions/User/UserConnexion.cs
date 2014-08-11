using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Ressources.User;

namespace DansTesComs.Core.Models.ModelsExtentions
{
    [MetadataType(typeof(UserConnexionMetadata))]
    public class UserConnexion
    {
        public string Mail { get; set; }
        public string Pass { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserConnexionMetadata 
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PassObligatoire")]
        [Display(ResourceType = typeof(UserRessources), Name = "PassLabel")]
        public string Pass { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError", ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        public string Mail { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "RememberMeLabel")]
        public bool RememberMe { get; set; }
    }
}

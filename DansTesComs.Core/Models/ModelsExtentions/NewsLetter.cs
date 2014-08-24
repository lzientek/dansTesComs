using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Core.Models.ModelsExtentions;
using DansTesComs.Ressources.User;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof(NewsLetterMetaData))]
    public partial class NewsLetter
    {
    }

    public class NewsLetterMetaData
    {
        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError", ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        public string Mail { get; set; }
    }
}

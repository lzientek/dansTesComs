// DansTesComs -> DansTesComs.WebSite ->UserExt.cs
// fichier créée le 09/07/2014 a 19:56
// par lucas zientek ( lucas )

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using DansTesComs.Core.Attribute.DateValidator;
using DansTesComs.Ressources.User;

namespace DansTesComs.Core.Models
{
    [MetadataType(typeof (UserMetadata))]
    public partial class User
    {
        public bool RememberMe { get; set; }

        public string GetGravatarLink(int size =40)
        {
            //on transforme le mail en hash
            var h = MD5.Create();
            byte[] data = h.ComputeHash(Encoding.UTF8.GetBytes(this.Mail));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            const string defaultUrl = "https://m1.behance.net/rendition/modules/79984489/disp/361c94db5ab26c0584806ea0a5e14807.png";
            return string.Format("http://www.gravatar.com/avatar.php?gravatar_id={0}&default={1}&s={2}", sBuilder, defaultUrl, size);
        }
    }


    public class UserMetadata
    {
        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError",ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        public string Mail { get; set; }

        [MaxLength(80, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "LongueurMax80")]
        [Display(ResourceType = typeof(UserRessources), Name = "NomLabel")]
        public string Nom { get; set; }

        [MaxLength(80, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "LongueurMax80")]
        [Display(ResourceType = typeof(UserRessources), Name = "PrenomLabel")]
        public string Prenom { get; set; }


        [Display(ResourceType = typeof(UserRessources), Name = "AnniversaireLabel")]
        [DataType(DataType.Date)]
        public DateTime Anniversaire { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PseudoObligatoire")]
        [Display(ResourceType = typeof(UserRessources), Name = "PseudoLabel")]
        [System.Web.Mvc.Remote("IsUserPseudoAvailable", "User", ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PseudoDejaUtilise")]
        [RegularExpression(RegexPattern.PseudoValidRegex, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PseudoRegex")]
        public string Pseudo { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "RememberMeLabel")]
        public bool RememberMe { get; set; }
    }
}
// DansTesComs -> DansTesComs.WebSite ->UserExt.cs
// fichier créée le 09/07/2014 a 19:56
// par lucas zientek ( lucas )

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DansTesComs.WebSite.Models
{
    [MetadataType(typeof (UserMetadata))]
    public partial class User
    {
        public bool RememberMe { get; set; }
        public string Pass { get; set; }
    }


    public class UserMetadata
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email obligatoire.")]
        public string Mail { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Nom obligatoire.")]
        public string Nom { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Prenom obligatoire.")]
        public string Prenom { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mot de passe obligatoire.")]
        [DisplayName("Mot de passe")]
        public string Pass { get; set; }

        [DataType(DataType.Date)]
        public DateTime Anniversaire { get; set; }

        [Required(ErrorMessage = "Pseudo obligatoire")]
        [RegularExpression("[a-zA-Z0-9]+",ErrorMessage = "minuscule, majuscule et chiffre uniquement")]
        public string Pseudo { get; set; }

        [DisplayName("Se souvenir de moi")]
        public bool RememberMe { get; set; }
    }
}
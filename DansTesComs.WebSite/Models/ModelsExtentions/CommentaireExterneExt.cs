using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using DansTesComs.Core;

namespace DansTesComs.WebSite.Models
{
    [MetadataType(typeof(CommentaireExterneMetaData))]
    public partial class CommentaireExterne
    {
        public void removeEmptyComs()
        {
            //on parcours a l'envers normal on supprime! si tu sais pas pourquoi google
            for (int i = CommentairesExterneContents.Count - 1; i >=0; i--)
            {
                var item = CommentairesExterneContents.ElementAt(i);
                if (string.IsNullOrEmpty(item.Commentaire) || string.IsNullOrEmpty(item.Pseudo))
                {
                    CommentairesExterneContents.Remove(item);
                }
            }
        }
    }


    public class CommentaireExterneMetaData
    {
        [MaxLength(50, ErrorMessage = "Titre trop long!")]
        [Required(ErrorMessage = "Titre obligatoire.")]
        public string Titre { get; set; }

        [MaxLength(500,ErrorMessage = "Ne peut pas dépacer 500 caractères.")]
        [DataType(DataType.MultilineText)]
        public string Publication { get; set; }

        [MaxLength(200,ErrorMessage = "Url trop longue...")]
        [DataType(DataType.Url,ErrorMessage = "Doit etre sous forme d'un lien...")]
        public string Lien { get; set; }
    }

}